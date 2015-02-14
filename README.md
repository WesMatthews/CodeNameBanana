# CodeNameBanana
#Test Database Script
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: 127.0.0.1	Database: ppsoft
-- ------------------------------------------------------
-- Server version    5.6.23-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `access_level`
--

DROP TABLE IF EXISTS `access_level`;
/*!40101 SET @saved_cs_client 	= @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `access_level` (
  `access_levelID` int(11) NOT NULL AUTO_INCREMENT,
  `access` varchar(45) NOT NULL,
  PRIMARY KEY (`access_levelID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `access_level`
--

LOCK TABLES `access_level` WRITE;
/*!40000 ALTER TABLE `access_level` DISABLE KEYS */;
INSERT INTO `access_level` VALUES (1,'full'),(2,'manager'),(3,'employee');
/*!40000 ALTER TABLE `access_level` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client 	= @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `department` (
  `departmentID` int(11) NOT NULL AUTO_INCREMENT,
  `department` varchar(45) NOT NULL,
  PRIMARY KEY (`departmentID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'Technology'),(2,'Tech Center'),(3,'Receiving'),(4,'Furniture'),(5,'Office Supplies'),(6,'Copy Center'),(7,'Front End');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client 	= @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `employeeID` int(11) NOT NULL AUTO_INCREMENT,
  `password` varchar(45) NOT NULL,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `access_levelID` int(11) NOT NULL,
  `sunStart` time DEFAULT NULL,
  `sunEnd` time DEFAULT NULL,
  `monStart` time DEFAULT NULL,
  `monEnd` time DEFAULT NULL,
  `tueStart` time DEFAULT NULL,
  `tueEnd` time DEFAULT NULL,
  `wedStart` time DEFAULT NULL,
  `wedEnd` time DEFAULT NULL,
  `thuStart` time DEFAULT NULL,
  `thuEnd` time DEFAULT NULL,
  `friStart` time DEFAULT NULL,
  `friEnd` time DEFAULT NULL,
  `satStart` time DEFAULT NULL,
  `satEnd` time DEFAULT NULL,
  PRIMARY KEY (`employeeID`),
  KEY `accessLevelId_idx` (`access_levelID`),
  CONSTRAINT `accessLevelId` FOREIGN KEY (`access_levelID`) REFERENCES `access_level` (`access_levelID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (11,'Password1','Darryl','Rutledge',2,'06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00'),(12,'Password1','Wes','Matthews',1,'06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00'),(13,'Password1','David','Murphy',2,'06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00'),(14,'Password1','Janet','Reno',3,'06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00'),(15,'Password1','Randy','Marsh',3,'06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00','06:00:00','21:00:00');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shift`
--

DROP TABLE IF EXISTS `shift`;
/*!40101 SET @saved_cs_client 	= @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `shift` (
  `shiftID` int(11) NOT NULL AUTO_INCREMENT,
  `employeeID` int(11) NOT NULL,
  `date` date NOT NULL,
  `startTime` time NOT NULL,
  `endTime` time NOT NULL,
  `departmentID` int(11) NOT NULL,
  PRIMARY KEY (`shiftID`),
  KEY `employeeID_idx` (`employeeID`),
  KEY `departmentID_idx` (`departmentID`),
  CONSTRAINT `departmentID` FOREIGN KEY (`departmentID`) REFERENCES `department` (`departmentID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `employeeID` FOREIGN KEY (`employeeID`) REFERENCES `employee` (`employeeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='   	 ';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shift`
--

LOCK TABLES `shift` WRITE;
/*!40000 ALTER TABLE `shift` DISABLE KEYS */;
INSERT INTO `shift` VALUES (1,1,'2015-02-16','06:00:00','14:00:00',1),(2,1,'2015-02-17','06:00:00','14:00:00',2),(3,2,'2015-02-16','14:00:00','21:00:00',3),(4,2,'2015-02-17','14:00:00','21:00:00',2),(5,3,'2015-02-16','06:00:00','14:00:00',5),(6,3,'2015-02-17','06:00:00','14:00:00',4),(7,4,'2015-02-16','14:00:00','21:00:00',3),(8,4,'2015-02-17','14:00:00','21:00:00',6),(9,5,'2015-02-16','06:00:00','14:00:00',4),(10,5,'2015-02-17','06:00:00','14:00:00',2);
/*!40000 ALTER TABLE `shift` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-02-13 20:52:50
