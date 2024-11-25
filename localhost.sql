-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:3306
-- Généré le : lun. 25 nov. 2024 à 08:41
-- Version du serveur : 5.7.24
-- Version de PHP : 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `ap1`
--
CREATE DATABASE IF NOT EXISTS `ap1` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ap1`;

-- --------------------------------------------------------

--
-- Structure de la table `etat`
--

CREATE TABLE `etat` (
  `id_etat` varchar(11) NOT NULL DEFAULT 'en cour',
  `etat` varchar(50) NOT NULL DEFAULT 'en cour'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `etat`
--

INSERT INTO `etat` (`id_etat`, `etat`) VALUES
('1', 'en attente'),
('3', 'refuser'),
('4', 'accepter'),
('5', 'en cour');

-- --------------------------------------------------------

--
-- Structure de la table `feuille tarif`
--

CREATE TABLE `feuille tarif` (
  `id_feu` int(11) NOT NULL,
  `montant` float NOT NULL,
  `nom` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `feuille tarif`
--

INSERT INTO `feuille tarif` (`id_feu`, `montant`, `nom`) VALUES
(1, 80, 'Nuité'),
(2, 20, 'Repas'),
(3, 0.665, 'Frais_Kilométrique');

-- --------------------------------------------------------

--
-- Structure de la table `fiche frais`
--

CREATE TABLE `fiche frais` (
  `id_fra` int(11) NOT NULL,
  `date_de_modification` date NOT NULL,
  `id_log` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `fiche frais`
--

INSERT INTO `fiche frais` (`id_fra`, `date_de_modification`, `id_log`) VALUES
(1, '2024-06-05', 3),
(2, '2024-06-11', 4),
(5, '2024-07-17', 4);

-- --------------------------------------------------------

--
-- Structure de la table `forfait`
--

CREATE TABLE `forfait` (
  `id_for` int(11) NOT NULL,
  `montant` float DEFAULT NULL,
  `quantité` int(50) NOT NULL,
  `id_feu` int(11) NOT NULL DEFAULT '1',
  `id_etat` varchar(11) NOT NULL DEFAULT 'en cour',
  `id_fra` int(11) NOT NULL DEFAULT '1',
  `date_de_modification` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `forfait`
--

INSERT INTO `forfait` (`id_for`, `montant`, `quantité`, `id_feu`, `id_etat`, `id_fra`, `date_de_modification`) VALUES
(6, 160, 2, 1, '5', 1, '2024-06-24'),
(8, 20, 1, 2, '5', 2, '2024-06-25'),
(16, 40, 2, 2, '5', 2, '2024-06-25'),
(17, 60, 3, 2, '5', 2, '2024-06-25'),
(29, 480, 6, 1, '5', 5, '2024-07-29');

-- --------------------------------------------------------

--
-- Structure de la table `hors forfait`
--

CREATE TABLE `hors forfait` (
  `id_hor` int(11) NOT NULL,
  `montant` float NOT NULL,
  `date_de_modification` date NOT NULL,
  `id_fra` int(200) NOT NULL DEFAULT '1',
  `nom` varchar(50) NOT NULL,
  `id_etat` varchar(11) NOT NULL DEFAULT 'en cour'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `hors forfait`
--

INSERT INTO `hors forfait` (`id_hor`, `montant`, `date_de_modification`, `id_fra`, `nom`, `id_etat`) VALUES
(2, 15, '2024-06-05', 1, 'Ordinateur', '5'),
(3, 15, '2024-05-24', 1, 'TEST', '5'),
(4, 80, '2024-06-12', 1, 'TEST', '5'),
(7, 20.5, '2024-06-24', 2, 'lunette', '5'),
(11, 20.5, '2024-06-24', 2, 'lunette', '5'),
(12, 12, '2024-07-22', 5, 'sdsqdq', '5'),
(13, 12, '2024-07-22', 5, 'qsqdsqddsfds', '5'),
(14, 875, '2024-06-25', 5, 'esf', '5'),
(15, 875, '2024-06-25', 5, 'esf', '5'),
(16, 12, '2024-07-22', 5, 'qsqdsqddsfds', '5'),
(17, 12, '2024-07-22', 5, 'sdsqdq', '5'),
(18, 12, '2024-06-25', 5, 'azeza', '5'),
(19, 12, '2024-06-25', 5, 'azeza', '5'),
(20, 5, '2024-06-25', 5, 'TEQT', '5'),
(21, 5, '2024-06-25', 5, 'TEQT', '5'),
(22, 536, '2024-06-25', 5, 'sdf', '5'),
(23, 536, '2024-06-25', 5, 'sdf', '5'),
(24, 15, '2024-07-29', 5, 'azdzad', '5'),
(25, 15, '2024-07-29', 5, 'azdzad', '5');

-- --------------------------------------------------------

--
-- Structure de la table `roles`
--

CREATE TABLE `roles` (
  `id_rol` int(11) NOT NULL,
  `droit` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `roles`
--

INSERT INTO `roles` (`id_rol`, `droit`) VALUES
(1, '[comptable]'),
(2, '[Visiteur]'),
(3, '[administateur]');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

CREATE TABLE `utilisateur` (
  `id_log` int(11) NOT NULL DEFAULT '1',
  `identifiant` varchar(50) NOT NULL,
  `mots_de_passe` varchar(50) NOT NULL,
  `id_rol` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`id_log`, `identifiant`, `mots_de_passe`, `id_rol`) VALUES
(3, 'root', 'root', 1),
(4, 'visiteur', 'visiteur', 2),
(5, 'admin', 'admin', 3);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `etat`
--
ALTER TABLE `etat`
  ADD PRIMARY KEY (`id_etat`);

--
-- Index pour la table `feuille tarif`
--
ALTER TABLE `feuille tarif`
  ADD PRIMARY KEY (`id_feu`);

--
-- Index pour la table `fiche frais`
--
ALTER TABLE `fiche frais`
  ADD PRIMARY KEY (`id_fra`),
  ADD KEY `fk_id_log` (`id_log`);

--
-- Index pour la table `forfait`
--
ALTER TABLE `forfait`
  ADD PRIMARY KEY (`id_for`),
  ADD KEY `fk_id_etat2` (`id_etat`),
  ADD KEY `fk_id_feu` (`id_feu`),
  ADD KEY `fk_id_fra` (`id_fra`);

--
-- Index pour la table `hors forfait`
--
ALTER TABLE `hors forfait`
  ADD PRIMARY KEY (`id_hor`),
  ADD KEY `fk_id_fra` (`id_fra`),
  ADD KEY `fk_id_etat1` (`id_etat`);

--
-- Index pour la table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id_rol`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`id_log`),
  ADD KEY `fk_id_rol` (`id_rol`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `feuille tarif`
--
ALTER TABLE `feuille tarif`
  MODIFY `id_feu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `fiche frais`
--
ALTER TABLE `fiche frais`
  MODIFY `id_fra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `forfait`
--
ALTER TABLE `forfait`
  MODIFY `id_for` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT pour la table `hors forfait`
--
ALTER TABLE `hors forfait`
  MODIFY `id_hor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT pour la table `roles`
--
ALTER TABLE `roles`
  MODIFY `id_rol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `fiche frais`
--
ALTER TABLE `fiche frais`
  ADD CONSTRAINT `fk_id_log` FOREIGN KEY (`id_log`) REFERENCES `utilisateur` (`id_log`);

--
-- Contraintes pour la table `forfait`
--
ALTER TABLE `forfait`
  ADD CONSTRAINT `fk_id_etat2` FOREIGN KEY (`id_etat`) REFERENCES `etat` (`id_etat`),
  ADD CONSTRAINT `fk_id_feu` FOREIGN KEY (`id_feu`) REFERENCES `feuille tarif` (`id_feu`),
  ADD CONSTRAINT `fk_id_fra` FOREIGN KEY (`id_fra`) REFERENCES `fiche frais` (`id_fra`);

--
-- Contraintes pour la table `hors forfait`
--
ALTER TABLE `hors forfait`
  ADD CONSTRAINT `fk_id_etat1` FOREIGN KEY (`id_etat`) REFERENCES `etat` (`id_etat`),
  ADD CONSTRAINT `fk_id_fra2` FOREIGN KEY (`id_fra`) REFERENCES `fiche frais` (`id_fra`);

--
-- Contraintes pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD CONSTRAINT `utilisateur_ibfk_1` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id_rol`);
--
-- Base de données : `ap2`
--
CREATE DATABASE IF NOT EXISTS `ap2` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `ap2`;

-- --------------------------------------------------------

--
-- Structure de la table `antecedentmedicament`
--

CREATE TABLE `antecedentmedicament` (
  `AntecedentsAntecedentId` int(11) NOT NULL,
  `MedicamentsMedicamentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `antecedentpatient`
--

CREATE TABLE `antecedentpatient` (
  `AntecedentsAntecedentId` int(11) NOT NULL,
  `PatientsPatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `antecedents`
--

CREATE TABLE `antecedents` (
  `AntecedentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `incompatibilites`
--

CREATE TABLE `incompatibilites` (
  `IncompatibiliteId` int(11) NOT NULL,
  `Interdiction` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `incompatibilitespatient`
--

CREATE TABLE `incompatibilitespatient` (
  `IncompatibilitesIncompatibiliteId` int(11) NOT NULL,
  `PatientsPatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `medecin`
--

CREATE TABLE `medecin` (
  `MedecinId` int(11) NOT NULL,
  `Nom` longtext NOT NULL,
  `Identifiant` longtext NOT NULL,
  `Mots_de_passe` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `medecin`
--

INSERT INTO `medecin` (`MedecinId`, `Nom`, `Identifiant`, `Mots_de_passe`) VALUES
(1, 'Pierre', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Structure de la table `medicaments`
--

CREATE TABLE `medicaments` (
  `MedicamentId` int(11) NOT NULL,
  `Allergie` longtext NOT NULL,
  `Nom` longtext NOT NULL,
  `Posologie` longtext NOT NULL,
  `IncompatibiliteId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `medicaments`
--

INSERT INTO `medicaments` (`MedicamentId`, `Allergie`, `Nom`, `Posologie`, `IncompatibiliteId`) VALUES
(1, 'Aucune', 'Paracétamol', 'toutes les 6 heures', NULL),
(2, 'Pénicilline', 'Ibuprofène', '200 mg toutes les 8 heures', NULL),
(3, 'Aucune', 'Paracétamol', '500 mg toutes les 6 heures', NULL),
(4, 'Aucune', 'Ibuprofène', '200 mg toutes les 8 heures', NULL),
(5, 'Pénicilline', 'Amoxicilline', '500 mg toutes les 12 heures pendant 7 jours', NULL),
(6, 'Aucune', 'Aspirine', '300 mg toutes les 6 heures après un repas', NULL),
(7, 'Sulfa', 'Triméthoprime', '160 mg deux fois par jour pendant 5 jours', NULL),
(8, 'Pénicilline', 'Ibuprofène', '200 mg toutes les 8 heures', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `ordonnancemedicament`
--

CREATE TABLE `ordonnancemedicament` (
  `MedicamentsMedicamentId` int(11) NOT NULL,
  `OrdonnancesOrdonnanceId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `ordonnances`
--

CREATE TABLE `ordonnances` (
  `OrdonnanceId` int(11) NOT NULL,
  `Patologie` longtext NOT NULL,
  `MedecinId` int(11) NOT NULL,
  `PatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `ordonnances`
--

INSERT INTO `ordonnances` (`OrdonnanceId`, `Patologie`, `MedecinId`, `PatientId`) VALUES
(1, 'ZEfds', 1, 8);

-- --------------------------------------------------------

--
-- Structure de la table `patient`
--

CREATE TABLE `patient` (
  `PatientId` int(11) NOT NULL,
  `Age` int(11) NOT NULL,
  `Prenom` longtext NOT NULL,
  `Nom` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `patient`
--

INSERT INTO `patient` (`PatientId`, `Age`, `Prenom`, `Nom`) VALUES
(4, 10, 'Sophie', 'Bernard'),
(5, 38, 'Luc', 'Lefevre'),
(6, 5, 'ss', 's'),
(7, 523, 'dfv', 'df'),
(8, 18, 'Esteban', 'Allier');

-- --------------------------------------------------------

--
-- Structure de la table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241003135255_initialMigration', '8.0.1');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `antecedentmedicament`
--
ALTER TABLE `antecedentmedicament`
  ADD PRIMARY KEY (`AntecedentsAntecedentId`,`MedicamentsMedicamentId`),
  ADD KEY `IX_AntecedentMedicament_MedicamentsMedicamentId` (`MedicamentsMedicamentId`);

--
-- Index pour la table `antecedentpatient`
--
ALTER TABLE `antecedentpatient`
  ADD PRIMARY KEY (`AntecedentsAntecedentId`,`PatientsPatientId`),
  ADD KEY `IX_AntecedentPatient_PatientsPatientId` (`PatientsPatientId`);

--
-- Index pour la table `antecedents`
--
ALTER TABLE `antecedents`
  ADD PRIMARY KEY (`AntecedentId`);

--
-- Index pour la table `incompatibilites`
--
ALTER TABLE `incompatibilites`
  ADD PRIMARY KEY (`IncompatibiliteId`);

--
-- Index pour la table `incompatibilitespatient`
--
ALTER TABLE `incompatibilitespatient`
  ADD PRIMARY KEY (`IncompatibilitesIncompatibiliteId`,`PatientsPatientId`),
  ADD KEY `IX_IncompatibilitesPatient_PatientsPatientId` (`PatientsPatientId`);

--
-- Index pour la table `medecin`
--
ALTER TABLE `medecin`
  ADD PRIMARY KEY (`MedecinId`);

--
-- Index pour la table `medicaments`
--
ALTER TABLE `medicaments`
  ADD PRIMARY KEY (`MedicamentId`),
  ADD KEY `IX_Medicaments_IncompatibiliteId` (`IncompatibiliteId`);

--
-- Index pour la table `ordonnancemedicament`
--
ALTER TABLE `ordonnancemedicament`
  ADD PRIMARY KEY (`MedicamentsMedicamentId`,`OrdonnancesOrdonnanceId`),
  ADD KEY `IX_OrdonnanceMedicament_OrdonnancesOrdonnanceId` (`OrdonnancesOrdonnanceId`);

--
-- Index pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  ADD PRIMARY KEY (`OrdonnanceId`),
  ADD UNIQUE KEY `IX_Ordonnances_PatientId` (`PatientId`),
  ADD KEY `IX_Ordonnances_MedecinId` (`MedecinId`);

--
-- Index pour la table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`PatientId`);

--
-- Index pour la table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `antecedents`
--
ALTER TABLE `antecedents`
  MODIFY `AntecedentId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `incompatibilites`
--
ALTER TABLE `incompatibilites`
  MODIFY `IncompatibiliteId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `medecin`
--
ALTER TABLE `medecin`
  MODIFY `MedecinId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `medicaments`
--
ALTER TABLE `medicaments`
  MODIFY `MedicamentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  MODIFY `OrdonnanceId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `patient`
--
ALTER TABLE `patient`
  MODIFY `PatientId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `antecedentmedicament`
--
ALTER TABLE `antecedentmedicament`
  ADD CONSTRAINT `FK_AntecedentMedicament_Antecedents_AntecedentsAntecedentId` FOREIGN KEY (`AntecedentsAntecedentId`) REFERENCES `antecedents` (`AntecedentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AntecedentMedicament_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `antecedentpatient`
--
ALTER TABLE `antecedentpatient`
  ADD CONSTRAINT `FK_AntecedentPatient_Antecedents_AntecedentsAntecedentId` FOREIGN KEY (`AntecedentsAntecedentId`) REFERENCES `antecedents` (`AntecedentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AntecedentPatient_Patient_PatientsPatientId` FOREIGN KEY (`PatientsPatientId`) REFERENCES `patient` (`PatientId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `incompatibilitespatient`
--
ALTER TABLE `incompatibilitespatient`
  ADD CONSTRAINT `FK_IncompatibilitesPatient_Incompatibilites_IncompatibilitesInc~` FOREIGN KEY (`IncompatibilitesIncompatibiliteId`) REFERENCES `incompatibilites` (`IncompatibiliteId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_IncompatibilitesPatient_Patient_PatientsPatientId` FOREIGN KEY (`PatientsPatientId`) REFERENCES `patient` (`PatientId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `medicaments`
--
ALTER TABLE `medicaments`
  ADD CONSTRAINT `FK_Medicaments_Incompatibilites_IncompatibiliteId` FOREIGN KEY (`IncompatibiliteId`) REFERENCES `incompatibilites` (`IncompatibiliteId`);

--
-- Contraintes pour la table `ordonnancemedicament`
--
ALTER TABLE `ordonnancemedicament`
  ADD CONSTRAINT `FK_OrdonnanceMedicament_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_OrdonnanceMedicament_Ordonnances_OrdonnancesOrdonnanceId` FOREIGN KEY (`OrdonnancesOrdonnanceId`) REFERENCES `ordonnances` (`OrdonnanceId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  ADD CONSTRAINT `FK_Ordonnances_Medecin_MedecinId` FOREIGN KEY (`MedecinId`) REFERENCES `medecin` (`MedecinId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Ordonnances_Patient_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `patient` (`PatientId`) ON DELETE CASCADE;
--
-- Base de données : `ap2sdfyu`
--
CREATE DATABASE IF NOT EXISTS `ap2sdfyu` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ap2sdfyu`;

-- --------------------------------------------------------

--
-- Structure de la table `antecedentmedicament`
--

CREATE TABLE `antecedentmedicament` (
  `AntecedentsAntecedentId` int(11) NOT NULL,
  `MedicamentsMedicamentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `antecedentpatient`
--

CREATE TABLE `antecedentpatient` (
  `AntecedentsAntecedentId` int(11) NOT NULL,
  `PatientsPatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `antecedentpatient`
--

INSERT INTO `antecedentpatient` (`AntecedentsAntecedentId`, `PatientsPatientId`) VALUES
(5, 6),
(12, 9);

-- --------------------------------------------------------

--
-- Structure de la table `antecedents`
--

CREATE TABLE `antecedents` (
  `AntecedentId` int(11) NOT NULL,
  `Nom` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `antecedents`
--

INSERT INTO `antecedents` (`AntecedentId`, `Nom`) VALUES
(1, ''),
(2, 'Cancer'),
(3, 'Cancer'),
(4, 'Diabète'),
(5, 'Cancer'),
(6, 'Diabète'),
(7, 'Hypertension'),
(8, 'Asthme'),
(9, 'Allergie alimentaire'),
(10, 'Maladie cardiaque'),
(11, 'Accident vasculaire cérébral'),
(12, 'Maladie rénale'),
(13, 'Arthrite'),
(14, 'Fibromyalgie');

-- --------------------------------------------------------

--
-- Structure de la table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `Identifiant` longtext NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `Identifiant`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('', 'test', 'test', 'test', 'test', 'test', 1, 'test', 'test', 'test', 'test', 1, 1, '2024-11-22 09:54:19.000000', 1, 1),
('admin', 'admin', 'admin', 'ADMIN', 'admin@example.com', 'ADMIN@EXAMPLE.COM', 0, 'hashed_password', NULL, NULL, NULL, 0, 0, NULL, 0, 0),
('NEW_MED_ID', 'a', 'medecin123', 'MEDECIN123', 'medecin@example.com', 'MEDECIN@EXAMPLE.COM', 1, 'a', 'f4375f93-1637-485d-907e-72b9d147b12d', 'c0f790a1-6f47-4d93-bd0f-9a5e56c9a6e0', '123-456-7890', 1, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Structure de la table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `incompatibilites`
--

CREATE TABLE `incompatibilites` (
  `IncompatibiliteId` int(11) NOT NULL,
  `Interdiction` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `incompatibilites`
--

INSERT INTO `incompatibilites` (`IncompatibiliteId`, `Interdiction`) VALUES
(1, 'Pénicilline');

-- --------------------------------------------------------

--
-- Structure de la table `incompatibilitespatient`
--

CREATE TABLE `incompatibilitespatient` (
  `IncompatibilitesIncompatibiliteId` int(11) NOT NULL,
  `PatientsPatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `medicaments`
--

CREATE TABLE `medicaments` (
  `MedicamentId` int(11) NOT NULL,
  `Allergie` longtext NOT NULL,
  `Nom` longtext NOT NULL,
  `Posologie` longtext NOT NULL,
  `IncompatibiliteId` int(11) DEFAULT NULL,
  `NombreUtilisations` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `medicaments`
--

INSERT INTO `medicaments` (`MedicamentId`, `Allergie`, `Nom`, `Posologie`, `IncompatibiliteId`, `NombreUtilisations`) VALUES
(2, 'Maux de tête', 'Doliprane', '2 comprimée par jour', NULL, 0);

-- --------------------------------------------------------

--
-- Structure de la table `ordonnancemedicament`
--

CREATE TABLE `ordonnancemedicament` (
  `MedicamentsMedicamentId` int(11) NOT NULL,
  `OrdonnancesOrdonnanceId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `ordonnances`
--

CREATE TABLE `ordonnances` (
  `OrdonnanceId` int(11) NOT NULL,
  `Patologie` longtext NOT NULL,
  `MedecinId` varchar(255) DEFAULT NULL,
  `PatientId` int(11) NOT NULL,
  `DateDébut` date NOT NULL,
  `DateFin` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `ordonnances`
--

INSERT INTO `ordonnances` (`OrdonnanceId`, `Patologie`, `MedecinId`, `PatientId`, `DateDébut`, `DateFin`) VALUES
(6, 'ad', NULL, 6, '2024-11-21', '2024-11-21');

-- --------------------------------------------------------

--
-- Structure de la table `patient`
--

CREATE TABLE `patient` (
  `PatientId` int(11) NOT NULL,
  `Age` int(11) NOT NULL,
  `Prenom` longtext NOT NULL,
  `Nom` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `patient`
--

INSERT INTO `patient` (`PatientId`, `Age`, `Prenom`, `Nom`) VALUES
(6, 2, 'Robin', 'Oudard'),
(7, 19, 'Alain', 'RABIE'),
(8, 20, 'Jean', 'Dupont'),
(9, 38, 'André', 'Pasteur');

-- --------------------------------------------------------

--
-- Structure de la table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241008145931_ap2dfghjk', '8.0.8');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `antecedentmedicament`
--
ALTER TABLE `antecedentmedicament`
  ADD PRIMARY KEY (`AntecedentsAntecedentId`,`MedicamentsMedicamentId`),
  ADD KEY `IX_AntecedentMedicament_MedicamentsMedicamentId` (`MedicamentsMedicamentId`);

--
-- Index pour la table `antecedentpatient`
--
ALTER TABLE `antecedentpatient`
  ADD PRIMARY KEY (`AntecedentsAntecedentId`,`PatientsPatientId`),
  ADD KEY `IX_AntecedentPatient_PatientsPatientId` (`PatientsPatientId`);

--
-- Index pour la table `antecedents`
--
ALTER TABLE `antecedents`
  ADD PRIMARY KEY (`AntecedentId`);

--
-- Index pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Index pour la table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Index pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Index pour la table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Index pour la table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Index pour la table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Index pour la table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Index pour la table `incompatibilites`
--
ALTER TABLE `incompatibilites`
  ADD PRIMARY KEY (`IncompatibiliteId`);

--
-- Index pour la table `incompatibilitespatient`
--
ALTER TABLE `incompatibilitespatient`
  ADD PRIMARY KEY (`IncompatibilitesIncompatibiliteId`,`PatientsPatientId`),
  ADD KEY `IX_IncompatibilitesPatient_PatientsPatientId` (`PatientsPatientId`);

--
-- Index pour la table `medicaments`
--
ALTER TABLE `medicaments`
  ADD PRIMARY KEY (`MedicamentId`),
  ADD KEY `IX_Medicaments_IncompatibiliteId` (`IncompatibiliteId`);

--
-- Index pour la table `ordonnancemedicament`
--
ALTER TABLE `ordonnancemedicament`
  ADD PRIMARY KEY (`MedicamentsMedicamentId`,`OrdonnancesOrdonnanceId`),
  ADD KEY `IX_OrdonnanceMedicament_OrdonnancesOrdonnanceId` (`OrdonnancesOrdonnanceId`);

--
-- Index pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  ADD PRIMARY KEY (`OrdonnanceId`),
  ADD UNIQUE KEY `IX_Ordonnances_PatientId` (`PatientId`),
  ADD KEY `IX_Ordonnances_MedecinId` (`MedecinId`);

--
-- Index pour la table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`PatientId`);

--
-- Index pour la table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `antecedents`
--
ALTER TABLE `antecedents`
  MODIFY `AntecedentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `incompatibilites`
--
ALTER TABLE `incompatibilites`
  MODIFY `IncompatibiliteId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `medicaments`
--
ALTER TABLE `medicaments`
  MODIFY `MedicamentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  MODIFY `OrdonnanceId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pour la table `patient`
--
ALTER TABLE `patient`
  MODIFY `PatientId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `antecedentmedicament`
--
ALTER TABLE `antecedentmedicament`
  ADD CONSTRAINT `FK_AntecedentMedicament_Antecedents_AntecedentsAntecedentId` FOREIGN KEY (`AntecedentsAntecedentId`) REFERENCES `antecedents` (`AntecedentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AntecedentMedicament_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `antecedentpatient`
--
ALTER TABLE `antecedentpatient`
  ADD CONSTRAINT `FK_AntecedentPatient_Antecedents_AntecedentsAntecedentId` FOREIGN KEY (`AntecedentsAntecedentId`) REFERENCES `antecedents` (`AntecedentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AntecedentPatient_Patient_PatientsPatientId` FOREIGN KEY (`PatientsPatientId`) REFERENCES `patient` (`PatientId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `incompatibilitespatient`
--
ALTER TABLE `incompatibilitespatient`
  ADD CONSTRAINT `FK_IncompatibilitesPatient_Incompatibilites_IncompatibilitesInc~` FOREIGN KEY (`IncompatibilitesIncompatibiliteId`) REFERENCES `incompatibilites` (`IncompatibiliteId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_IncompatibilitesPatient_Patient_PatientsPatientId` FOREIGN KEY (`PatientsPatientId`) REFERENCES `patient` (`PatientId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `medicaments`
--
ALTER TABLE `medicaments`
  ADD CONSTRAINT `FK_Medicaments_Incompatibilites_IncompatibiliteId` FOREIGN KEY (`IncompatibiliteId`) REFERENCES `incompatibilites` (`IncompatibiliteId`);

--
-- Contraintes pour la table `ordonnancemedicament`
--
ALTER TABLE `ordonnancemedicament`
  ADD CONSTRAINT `FK_OrdonnanceMedicament_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_OrdonnanceMedicament_Ordonnances_OrdonnancesOrdonnanceId` FOREIGN KEY (`OrdonnancesOrdonnanceId`) REFERENCES `ordonnances` (`OrdonnanceId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  ADD CONSTRAINT `FK_Ordonnances_AspNetUsers_MedecinId` FOREIGN KEY (`MedecinId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Ordonnances_Patient_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `patient` (`PatientId`) ON DELETE CASCADE;
--
-- Base de données : `bts test`
--
CREATE DATABASE IF NOT EXISTS `bts test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `bts test`;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
