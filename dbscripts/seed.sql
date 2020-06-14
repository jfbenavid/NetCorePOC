\connect testDb

CREATE TABLE Users
(
 Id serial PRIMARY KEY,
 Name VARCHAR (100) NOT NULL,
 Email VARCHAR (100) NOT NULL,
 Balance INT NOT NULL
);

--ALTER TABLE User OWNER TO bloguser;
Insert into Users(Name, Email, Balance) values( 'Name 1','Email 1', 12345);
Insert into Users(Name, Email, Balance) values( 'Name 2','Email 2', 12654);
Insert into Users(Name, Email, Balance) values( 'Name 3','Email 3', 12987);
Insert into Users(Name, Email, Balance) values( 'Name 4','Email 4', 16485);