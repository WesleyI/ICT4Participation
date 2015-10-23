drop table Account cascade constraints;	
drop table Hulpvraag cascade constraints;
drop table Kennismakingsgesprek cascade constraints;
drop table Chatbericht cascade constraints;
drop table Recensie cascade constraints;
drop table Reactie cascade constraints;

Create table Account			
	(
   AccountID number(10),
   Emailadres	varchar2(30) not null, 
	 Wachtwoord	varchar2(30) not null, 
	 Discriminator varchar2(1) not null, 
   Woonplaats varchar2(50) null,
   Straatnaam varchar2(50) null,
   Huisnummer varchar2(20) null,
   Telefoonnummer varchar2(30) null,
   Voornaam varchar2(50) null,
   Achternaam varchar2(50) null,
   Geboortedatum date null,
   Biografie varchar2(1020) null,
   Competenties varchar2(255) null,
   Vervoer  varchar2(255) null,
   Beschikbaarheid varchar2(255) null,
   LocatieVOG varchar2(255) null,
   LocatieFoto varchar2(255) null,
   Probleemstelling varchar2(255) null,
	 PRIMARY KEY (AccountID), 
   CONSTRAINT check_Discriminator CHECK(Upper(Discriminator) = 'V' OR Upper(Discriminator) = 'H' OR Upper(Discriminator) = 'B')
	);	
  
DROP SEQUENCE accountseq;
CREATE SEQUENCE accountseq;

CREATE OR REPLACE TRIGGER Account_trigger 
BEFORE INSERT ON Account 
FOR EACH ROW
BEGIN
  SELECT accountseq.NEXTVAL
  INTO   :new.AccountID
  FROM   dual;
END;
/
  
--Testdata Account:
INSERT INTO "ACCOUNT" (ACCOUNTID, EMAILADRES, WACHTWOORD, DISCRIMINATOR, WOONPLAATS, STRAATNAAM, HUISNUMMER, TELEFOONNUMMER, VOORNAAM, ACHTERNAAM, GEBOORTEDATUM, BIOGRAFIE, COMPETENTIES, VERVOER, BESCHIKBAARHEID, LOCATIEVOG) 
VALUES ('1', 'vrijwillig@hotmail.com', 'vrij123', 'V', 'Vught', 'Taxandrialaan', '12', '0616108054', 'Walter', 'Kuijlaars', TO_DATE('1995-04-17 07:55:28', 'YYYY-MM-DD HH24:MI:SS'), 'Hoi ik ben walter', 'ik kan vliegen', 'OV', 'MA en DI', 'Ja');

INSERT INTO "ACCOUNT" (ACCOUNTID, EMAILADRES, WACHTWOORD, DISCRIMINATOR, WOONPLAATS, STRAATNAAM, HUISNUMMER, TELEFOONNUMMER, VOORNAAM, ACHTERNAAM, GEBOORTEDATUM, BIOGRAFIE, PROBLEEMSTELLING) 
VALUES ('2', 'hulp@hotmail.com', 'hulp123', 'H', 'Eindhoven', 'Kruidhoeve', '32', '0736569782', 'Piet', 'Jansen', TO_DATE('1951-10-17 07:57:44', 'YYYY-MM-DD HH24:MI:SS'), 'hoi', 'Ik heb hulp nodig met friet bakken');

INSERT INTO "ACCOUNT" (ACCOUNTID, EMAILADRES, WACHTWOORD, DISCRIMINATOR) 
VALUES ('3', 'beheer@hotmail.com', 'beheer123', 'B');

Create table Hulpvraag
  (
  HulpvraagID number(10), --De primary key van ConctactAanvraag
  Tekstprobleem varchar2(1020) not null, --De andere properties van Contactaanvraag
  Aanmaakdatum date not null,
  Begindatum date null,
  Duur varchar2(50) null,
  Urgent varchar2(1) not null,
  fkAccountID number(10) not null, --foreign key naar Persoon
  PRIMARY KEY (HulpvraagID),
  FOREIGN KEY (fkAccountID) REFERENCES Account(AccountID)
  );
  
--Testdata Hulpvraag:
INSERT INTO "HULPVRAAG" (HULPVRAAGID, TEKSTPROBLEEM, AANMAAKDATUM, BEGINDATUM, DUUR, URGENT, FKACCOUNTID) 
VALUES ('1', 'Ik wil hulp met frietjes', TO_DATE('2015-10-15 08:01:11', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2015-10-24 08:01:18', 'YYYY-MM-DD HH24:MI:SS'), '1 avond', 'Y', '2');

INSERT INTO "HULPVRAAG" (HULPVRAAGID, TEKSTPROBLEEM, AANMAAKDATUM, BEGINDATUM, DUUR, URGENT, FKACCOUNTID) 
VALUES ('2', 'Ik wil nog meer friet', TO_DATE('2015-10-24 08:02:14', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2015-10-31 08:02:17', 'YYYY-MM-DD HH24:MI:SS'), '1 avond', 'N', '2');

Create table Kennismakingsgesprek
  (
  KennismakingsgesprekID number(10), --De primary key van Zoekwoord
  Datum date not null, --De andere properties van Zoekwoord
  Tekst varchar2(255) null,
  fkAccountID number(10) not null, --foreign key naar Persoon
  PRIMARY KEY (KennismakingsgesprekID),
  FOREIGN KEY (fkAccountID) REFERENCES Account(AccountID)
  );
  
--Testdata Kennismakingsgesprek:
INSERT INTO "KENNISMAKINGSGESPREK" (KENNISMAKINGSGESPREKID, DATUM, TEKST, FKACCOUNTID) 
VALUES ('1', TO_DATE('2015-10-17 08:04:21', 'YYYY-MM-DD HH24:MI:SS'), 'Hallo walter, wil jij mij helpen?', '2');

Create table Chatbericht
  (
  ChatberichtID number(10),  --De primary key van Categorie
  Tekst varchar2(255) not null,
  Datum date not null,
  fkOntvanger number(10),
  fkVerzender number(10),
  PRIMARY KEY (ChatberichtID),
  FOREIGN KEY (fkOntvanger) REFERENCES Account(AccountID),
  FOREIGN KEY (fkVerzender) REFERENCES Account(AccountID)
  );
  
--Testdata Chatbericht
INSERT INTO "CHATBERICHT" (CHATBERICHTID, TEKST, DATUM, FKONTVANGER, FKVERZENDER) 
VALUES ('1', 'Hallo piet, fack off', TO_DATE('2015-10-17 08:05:27', 'YYYY-MM-DD HH24:MI:SS'), '2', '1');

INSERT INTO "CHATBERICHT" (CHATBERICHTID, TEKST, DATUM, FKONTVANGER, FKVERZENDER) 
VALUES ('2', 'Dat vind ik niet aardig', TO_DATE('2015-10-17 08:05:37', 'YYYY-MM-DD HH24:MI:SS'), '1', '2');

INSERT INTO "CHATBERICHT" (CHATBERICHTID, TEKST, DATUM, FKONTVANGER, FKVERZENDER) 
VALUES ('3', 'Dat boeit me niet', TO_DATE('2015-10-17 08:05:48', 'YYYY-MM-DD HH24:MI:SS'), '2', '1');

Create table Recensie
  (
  RecensieID number(10), 
  Tekst varchar2(1020) not null, 
  Datum date not null, 
  Beoordeling number(4) null,
  fkOntvanger number(10),
  fkVerzender number(10),
  PRIMARY KEY (RecensieID),
  FOREIGN KEY (fkOntvanger) REFERENCES Account(AccountID),
  FOREIGN KEY (fkVerzender) REFERENCES Account(AccountID)
  );
  
--Testdata Recensie
INSERT INTO "RECENSIE" (RECENSIEID, TEKST, DATUM, BEOORDELING, FKONTVANGER, FKVERZENDER) 
VALUES ('1', 'Walter deed niet aardig', TO_DATE('2015-10-17 08:06:32', 'YYYY-MM-DD HH24:MI:SS'), '1', '1', '2');
  
Create table Reactie
  (
  ReactieID number(10), --De primary key van Antwoord
  Tekst varchar2(1020) not null, --De andere propertie van Antwoord
  Datum date not null,
  fkAccountID number(10) not null, --foreign key naar Vraag
  fkRecensieID number(10) not null, --foreign key naar Persoon
  PRIMARY KEY (ReactieID),
  FOREIGN KEY (fkAccountID) REFERENCES Account(AccountID),
  FOREIGN KEY (fkRecensieID) REFERENCES Recensie(RecensieID)
  );
  
--Testdata Reactie
INSERT INTO "REACTIE" (REACTIEID, TEKST, DATUM, FKACCOUNTID, FKRECENSIEID) 
VALUES ('1', 'Ik heb piet nooit gemogen...', TO_DATE('2015-10-17 08:06:32', 'YYYY-MM-DD HH24:MI:SS'), '1', '1');
INSERT INTO "REACTIE" (REACTIEID, TEKST, DATUM, FKACCOUNTID, FKRECENSIEID) 
VALUES ('2', 'Een random reactie', TO_DATE('2015-10-17 08:06:32', 'YYYY-MM-DD HH24:MI:SS'), '1', '1');
INSERT INTO "REACTIE" (REACTIEID, TEKST, DATUM, FKACCOUNTID, FKRECENSIEID) 
VALUES ('3', 'Een test reactie', TO_DATE('2015-10-17 08:06:32', 'YYYY-MM-DD HH24:MI:SS'), '1', '1');

