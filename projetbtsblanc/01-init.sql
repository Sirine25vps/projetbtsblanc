-- TABLES "PARENTS" (Sans clés étrangères)
CREATE TABLE PATIENT (
    numPatient INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    dateNaissance DATE NOT NULL,
    numeroSecu VARCHAR(15) UNIQUE NOT NULL
);

CREATE TABLE MEDECIN (
    numMedecin INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    dateNaissance DATE NOT NULL,
    numeroRPPS VARCHAR(15) UNIQUE NOT NULL
);

CREATE TABLE MEDICAMENT (
    codeMedicament INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL
);

CREATE TABLE ALLERGIE (
    codeAllergie INT AUTO_INCREMENT PRIMARY KEY,
    libelle VARCHAR(50) UNIQUE NOT NULL
);

-- TABLES "ENFANTS" (Avec clés étrangères)
CREATE TABLE ORDONNANCE (
    numOrdonnance INT AUTO_INCREMENT PRIMARY KEY,
    numPatient INT NOT NULL,
    numMedecin INT NOT NULL,
    FOREIGN KEY (numPatient) REFERENCES PATIENT(numPatient) ON DELETE RESTRICT,
    FOREIGN KEY (numMedecin) REFERENCES MEDECIN(numMedecin) ON DELETE RESTRICT
);

CREATE TABLE CONTENIR (
    numOrdonnance INT NOT NULL,
    codeMedicament INT NOT NULL,
    posologie VARCHAR(100) NOT NULL,
    dureeJours INT NOT NULL,
    PRIMARY KEY (numOrdonnance, codeMedicament),
    FOREIGN KEY (numOrdonnance) REFERENCES ORDONNANCE(numOrdonnance) ON DELETE CASCADE,
    FOREIGN KEY (codeMedicament) REFERENCES MEDICAMENT(codeMedicament) ON DELETE RESTRICT
);

CREATE TABLE ETRE_ALLERGIQUE (
    numPatient INT NOT NULL,
    codeAllergie INT NOT NULL,
    PRIMARY KEY (numPatient, codeAllergie),
    FOREIGN KEY (numPatient) REFERENCES PATIENT(numPatient) ON DELETE CASCADE,
    FOREIGN KEY (codeAllergie) REFERENCES ALLERGIE(codeAllergie) ON DELETE RESTRICT
);

-- JEU DE TEST MINIMAL
-- Patients
INSERT INTO PATIENT (nom, prenom, dateNaissance, numeroSecu) VALUES
('DUPONT', 'Marie', '1985-03-14', '2850314123456'),
('LEROY', 'Jean', '1960-07-22', '1600722123456');

-- Médecins
INSERT INTO MEDECIN (nom, prenom, dateNaissance, numeroRPPS) VALUES
('DURAND', 'Marc', '1975-05-10', '12345678901'),
('MARTIN', 'Sophie', '1980-11-20', '10987654321');

-- Médicaments et Allergies
INSERT INTO MEDICAMENT (nom) VALUES ('Doliprane 500 mg'), ('Amoxicilline 1 g');
INSERT INTO ALLERGIE (libelle) VALUES ('Pénicilline'), ('Aspirine');

-- Création d'au moins une ordonnance pour Marie DUPONT avec deux lignes
INSERT INTO ORDONNANCE (numPatient, numMedecin) VALUES (1, 1); 
INSERT INTO CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours) VALUES
(1, 1, '1 matin, midi et soir', 5),
(1, 2, '1 matin et soir', 7);