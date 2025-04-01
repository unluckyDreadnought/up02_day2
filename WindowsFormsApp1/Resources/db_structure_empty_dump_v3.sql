CREATE DATABASE  IF NOT EXISTS `project_office` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `project_office`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: project_office
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `ClientID` int NOT NULL AUTO_INCREMENT,
  `ClientTypeID` int NOT NULL,
  `ClientOrgTypeID` varchar(4) DEFAULT NULL,
  `ClientName` varchar(256) NOT NULL,
  `ClientAddress` varchar(256) NOT NULL,
  `ClientBankAccount` varchar(20) NOT NULL,
  `ClientBank` varchar(256) NOT NULL,
  `ClientPhone` varchar(11) DEFAULT NULL,
  `ClientEmail` varchar(256) DEFAULT NULL,
  `ClientOrgINN` varchar(10) DEFAULT NULL COMMENT 'Max size 6',
  `ClientOrgKPP` varchar(9) DEFAULT NULL,
  `ClientOrgOGRN` varchar(13) DEFAULT NULL,
  `ClientOrgBIK` varchar(9) DEFAULT NULL,
  `ClientPhoto` blob,
  PRIMARY KEY (`ClientID`),
  UNIQUE KEY `ClientBankAccount_UNIQUE` (`ClientBankAccount`),
  KEY `clienttype_ref_k_idx` (`ClientTypeID`),
  KEY `organitationtype_ref_k_idx` (`ClientOrgTypeID`),
  CONSTRAINT `clienttype_ref_k` FOREIGN KEY (`ClientTypeID`) REFERENCES `clienttype` (`ClientTypeID`),
  CONSTRAINT `organitationtype_ref_k` FOREIGN KEY (`ClientOrgTypeID`) REFERENCES `organitationtype` (`OrganitationTypeName`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clienttype`
--

DROP TABLE IF EXISTS `clienttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clienttype` (
  `ClientTypeID` int NOT NULL AUTO_INCREMENT,
  `ClientTypeName` varchar(15) NOT NULL,
  PRIMARY KEY (`ClientTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clienttype`
--

LOCK TABLES `clienttype` WRITE;
/*!40000 ALTER TABLE `clienttype` DISABLE KEYS */;
/*!40000 ALTER TABLE `clienttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `control_point_to_subtask`
--

DROP TABLE IF EXISTS `control_point_to_subtask`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `control_point_to_subtask` (
  `CntrPntLinkID` int NOT NULL AUTO_INCREMENT,
  `SbtskReferenceID` int NOT NULL,
  `ControlPointID` int NOT NULL,
  PRIMARY KEY (`CntrPntLinkID`),
  UNIQUE KEY `CntrPntLinkID` (`CntrPntLinkID`),
  KEY `cntrpntlink_sbtsklink_id_ref_k` (`SbtskReferenceID`),
  KEY `cntrpntlink_controlpoint_id_ref_k` (`ControlPointID`),
  CONSTRAINT `cntrpntlink_controlpoint_id_ref_k` FOREIGN KEY (`ControlPointID`) REFERENCES `controlpoint` (`ControlPointID`),
  CONSTRAINT `cntrpntlink_sbtsklink_id_ref_k` FOREIGN KEY (`SbtskReferenceID`) REFERENCES `subtask_in_project_stage` (`SbtskLinkID`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `control_point_to_subtask`
--

LOCK TABLES `control_point_to_subtask` WRITE;
/*!40000 ALTER TABLE `control_point_to_subtask` DISABLE KEYS */;
/*!40000 ALTER TABLE `control_point_to_subtask` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `controlpoint`
--

DROP TABLE IF EXISTS `controlpoint`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `controlpoint` (
  `ControlPointID` int NOT NULL AUTO_INCREMENT,
  `ControlPointAuthorID` int NOT NULL,
  `StatusID` int NOT NULL,
  `ControlPointTitle` varchar(100) DEFAULT NULL,
  `ControlPointDescription` text,
  `ControlPointDateTime` date NOT NULL,
  PRIMARY KEY (`ControlPointID`,`ControlPointDateTime`),
  KEY `status_ref_k_idx` (`StatusID`),
  CONSTRAINT `controlpoint_status_ref_k` FOREIGN KEY (`StatusID`) REFERENCES `status` (`StatusID`)
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `controlpoint`
--

LOCK TABLES `controlpoint` WRITE;
/*!40000 ALTER TABLE `controlpoint` DISABLE KEYS */;
/*!40000 ALTER TABLE `controlpoint` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventjournal`
--

DROP TABLE IF EXISTS `eventjournal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventjournal` (
  `EventID` int NOT NULL AUTO_INCREMENT,
  `EventTypeID` int NOT NULL,
  `UserID` int NOT NULL,
  `EventDateTime` datetime NOT NULL,
  `FormName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`EventID`),
  KEY `eventtype_ref_k_idx` (`EventTypeID`),
  KEY `user_ref_k_idx` (`UserID`),
  CONSTRAINT `eventtype_ref_k` FOREIGN KEY (`EventTypeID`) REFERENCES `eventtype` (`EventTypeID`),
  CONSTRAINT `user_ref_k` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=237 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventjournal`
--

LOCK TABLES `eventjournal` WRITE;
/*!40000 ALTER TABLE `eventjournal` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventjournal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventtype`
--

DROP TABLE IF EXISTS `eventtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventtype` (
  `EventTypeID` int NOT NULL AUTO_INCREMENT,
  `EventTypeName` varchar(30) NOT NULL,
  PRIMARY KEY (`EventTypeID`),
  UNIQUE KEY `EventTypeName_UNIQUE` (`EventTypeName`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventtype`
--

LOCK TABLES `eventtype` WRITE;
/*!40000 ALTER TABLE `eventtype` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organitationtype`
--

DROP TABLE IF EXISTS `organitationtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organitationtype` (
  `OrganitationTypeName` varchar(4) NOT NULL,
  `OrganitationTypeDescription` varchar(45) NOT NULL,
  PRIMARY KEY (`OrganitationTypeName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organitationtype`
--

LOCK TABLES `organitationtype` WRITE;
/*!40000 ALTER TABLE `organitationtype` DISABLE KEYS */;
/*!40000 ALTER TABLE `organitationtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `ProjectID` int NOT NULL AUTO_INCREMENT,
  `ProjectStatusID` int NOT NULL,
  `ProjectCustomerID` int DEFAULT NULL,
  `ProjectCreatorID` int NOT NULL,
  `ProjectTitle` varchar(256) NOT NULL,
  `ProjectStartDate` date NOT NULL,
  `ProjectPlanEndDate` date DEFAULT NULL,
  `ProjectFactEndDate` date DEFAULT NULL,
  `ProjectCoefficient` varchar(4) NOT NULL DEFAULT '0',
  `ProjectCost` double NOT NULL,
  PRIMARY KEY (`ProjectID`),
  KEY `client_ref_k_idx` (`ProjectCustomerID`),
  KEY `creator_ref_k_idx` (`ProjectCreatorID`),
  KEY `project_status_ref_k_idx` (`ProjectStatusID`),
  CONSTRAINT `client_ref_k` FOREIGN KEY (`ProjectCustomerID`) REFERENCES `client` (`ClientID`),
  CONSTRAINT `creator_ref_k` FOREIGN KEY (`ProjectCreatorID`) REFERENCES `user` (`UserID`),
  CONSTRAINT `project_status_ref_k` FOREIGN KEY (`ProjectStatusID`) REFERENCES `status` (`StatusID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `specialization`
--

DROP TABLE IF EXISTS `specialization`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `specialization` (
  `SpecializationID` int NOT NULL AUTO_INCREMENT,
  `SpecializationTitle` varchar(45) NOT NULL,
  PRIMARY KEY (`SpecializationID`),
  UNIQUE KEY `SpecializationTitle_UNIQUE` (`SpecializationTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specialization`
--

LOCK TABLES `specialization` WRITE;
/*!40000 ALTER TABLE `specialization` DISABLE KEYS */;
/*!40000 ALTER TABLE `specialization` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stage`
--

DROP TABLE IF EXISTS `stage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stage` (
  `StageID` int NOT NULL AUTO_INCREMENT,
  `StageTitle` varchar(60) NOT NULL,
  PRIMARY KEY (`StageID`),
  UNIQUE KEY `StageTitle_UNIQUE` (`StageTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stage`
--

LOCK TABLES `stage` WRITE;
/*!40000 ALTER TABLE `stage` DISABLE KEYS */;
INSERT INTO `stage` VALUES (4,'Документирование'),(1,'Проектирование'),(2,'Реализация'),(3,'Тестирование');
/*!40000 ALTER TABLE `stage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stage_in_project`
--

DROP TABLE IF EXISTS `stage_in_project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stage_in_project` (
  `StgLinkID` int NOT NULL AUTO_INCREMENT,
  `ProjectID` int NOT NULL,
  `StageID` int NOT NULL,
  PRIMARY KEY (`StgLinkID`),
  UNIQUE KEY `StgLinkID` (`StgLinkID`),
  KEY `stglink_project_id_ref_k` (`ProjectID`),
  KEY `stglink_stage_id_ref_k` (`StageID`),
  CONSTRAINT `stglink_project_id_ref_k` FOREIGN KEY (`ProjectID`) REFERENCES `project` (`ProjectID`),
  CONSTRAINT `stglink_stage_id_ref_k` FOREIGN KEY (`StageID`) REFERENCES `stage` (`StageID`)
) ENGINE=InnoDB AUTO_INCREMENT=4752 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stage_in_project`
--

LOCK TABLES `stage_in_project` WRITE;
/*!40000 ALTER TABLE `stage_in_project` DISABLE KEYS */;
/*!40000 ALTER TABLE `stage_in_project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `StatusID` int NOT NULL AUTO_INCREMENT,
  `StatusTitle` varchar(100) NOT NULL,
  PRIMARY KEY (`StatusID`),
  UNIQUE KEY `StatusTitle_UNIQUE` (`StatusTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subtask`
--

DROP TABLE IF EXISTS `subtask`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subtask` (
  `SubtaskID` int NOT NULL AUTO_INCREMENT,
  `SubtaskTitle` varchar(50) NOT NULL,
  PRIMARY KEY (`SubtaskID`),
  UNIQUE KEY `SubtaskTitle_UNIQUE` (`SubtaskTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subtask`
--

LOCK TABLES `subtask` WRITE;
/*!40000 ALTER TABLE `subtask` DISABLE KEYS */;
/*!40000 ALTER TABLE `subtask` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subtask_in_project_stage`
--

DROP TABLE IF EXISTS `subtask_in_project_stage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subtask_in_project_stage` (
  `SbtskLinkID` int NOT NULL AUTO_INCREMENT,
  `StgProjReferenceID` int NOT NULL,
  `SubtaskID` int NOT NULL,
  `SubtaskDescription` text,
  PRIMARY KEY (`SbtskLinkID`),
  UNIQUE KEY `SbtskLinkID` (`SbtskLinkID`),
  KEY `sbtsklink_stglink_id_ref_k` (`StgProjReferenceID`),
  KEY `sbtsklink_subtask_id_ref_k` (`SubtaskID`),
  CONSTRAINT `sbtsklink_stglink_id_ref_k` FOREIGN KEY (`StgProjReferenceID`) REFERENCES `stage_in_project` (`StgLinkID`),
  CONSTRAINT `sbtsklink_subtask_id_ref_k` FOREIGN KEY (`SubtaskID`) REFERENCES `subtask` (`SubtaskID`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subtask_in_project_stage`
--

LOCK TABLES `subtask_in_project_stage` WRITE;
/*!40000 ALTER TABLE `subtask_in_project_stage` DISABLE KEYS */;
/*!40000 ALTER TABLE `subtask_in_project_stage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `UserModeID` int NOT NULL,
  `UserSpecializationID` int DEFAULT NULL,
  `UserSurname` varchar(60) NOT NULL,
  `UserName` varchar(45) NOT NULL,
  `UserPatronymic` varchar(50) DEFAULT NULL,
  `UserLogin` varchar(100) DEFAULT NULL,
  `UserPassword` varchar(128) DEFAULT NULL,
  `UserPhoto` blob,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `UserLogin_UNIQUE` (`UserLogin`),
  KEY `usermode_ref_k_idx` (`UserModeID`),
  KEY `specialization_ref_k_idx` (`UserSpecializationID`),
  CONSTRAINT `specialization_ref_k` FOREIGN KEY (`UserSpecializationID`) REFERENCES `specialization` (`SpecializationID`),
  CONSTRAINT `usermode_ref_k` FOREIGN KEY (`UserModeID`) REFERENCES `usermode` (`UserModeID`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usermode`
--

DROP TABLE IF EXISTS `usermode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usermode` (
  `UserModeID` int NOT NULL AUTO_INCREMENT,
  `UserModeTitle` varchar(13) NOT NULL,
  PRIMARY KEY (`UserModeID`),
  UNIQUE KEY `UserModeTitle_UNIQUE` (`UserModeTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usermode`
--

LOCK TABLES `usermode` WRITE;
/*!40000 ALTER TABLE `usermode` DISABLE KEYS */;
/*!40000 ALTER TABLE `usermode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userproject`
--

DROP TABLE IF EXISTS `userproject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userproject` (
  `UserID` int NOT NULL,
  `ProjectID` int NOT NULL,
  `IsResponsible` tinyint DEFAULT '0',
  PRIMARY KEY (`UserID`,`ProjectID`),
  KEY `project_ref_k_idx` (`ProjectID`),
  CONSTRAINT `userproj_project_ref_k` FOREIGN KEY (`ProjectID`) REFERENCES `project` (`ProjectID`),
  CONSTRAINT `userproj_user_ref_k` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userproject`
--

LOCK TABLES `userproject` WRITE;
/*!40000 ALTER TABLE `userproject` DISABLE KEYS */;
/*!40000 ALTER TABLE `userproject` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-01 20:47:55
