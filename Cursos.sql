-- MySQL dump 10.13  Distrib 5.7.24, for osx11.1 (x86_64)
--
-- Host: localhost    Database: Cursos
-- ------------------------------------------------------
-- Server version	8.0.25

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
-- Table structure for table `Curso`
--

DROP TABLE IF EXISTS `Curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Curso` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Clave` varchar(10) DEFAULT NULL,
  `Nombre` varchar(200) DEFAULT NULL,
  `Descripcion` varchar(1000) DEFAULT NULL,
  `NoHoras` int DEFAULT NULL,
  `FechaInicio` datetime DEFAULT NULL,
  `FechaTermino` datetime DEFAULT NULL,
  `Costo` decimal(6,2) DEFAULT NULL,
  `Instructor` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Curso`
--

LOCK TABLES `Curso` WRITE;
/*!40000 ALTER TABLE `Curso` DISABLE KEYS */;
INSERT INTO `Curso` VALUES (1,'123456','Programación Nivel I','Curso der Programación',75,'2023-04-10 00:00:00','2023-06-01 00:00:00',900.00,'Yo'),(3,'345678','Programación II','Segundo curso',80,'3923-04-30 00:00:00','3923-04-30 00:00:00',900.00,'Dr. Francisco'),(7,'6897890','Algebra Lineal','Se analizan los conceptos de algebra lineal',40,'2023-05-01 00:00:00','2023-06-01 00:00:00',900.00,'Dr. X'),(8,'5897890','Algebra Lineal II','Se analizan los conceptos de algebra lineal',40,'2023-05-10 00:00:00','2023-06-01 00:00:00',900.00,'Dr. X'),(13,'44447','Programacion IV','Esta es una descripcin',20,'2023-05-10 00:00:00','2023-05-18 00:00:00',400.00,'Todos'),(14,'876876876','Matemáticas Discretas','Curso de matemáticas discretas',50,'2023-06-01 00:00:00','2023-07-01 00:00:00',467.00,'X');
/*!40000 ALTER TABLE `Curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Participante`
--

DROP TABLE IF EXISTS `Participante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Participante` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDCurso` int DEFAULT NULL,
  `Paterno` varchar(30) DEFAULT NULL,
  `Materno` varchar(30) DEFAULT NULL,
  `Nombre` varchar(30) DEFAULT NULL,
  `Matricula` varchar(20) DEFAULT NULL,
  `Precio` decimal(12,2) DEFAULT NULL,
  `Pagado` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDCurso` (`IDCurso`),
  CONSTRAINT `participante_ibfk_1` FOREIGN KEY (`IDCurso`) REFERENCES `Curso` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Participante`
--

LOCK TABLES `Participante` WRITE;
/*!40000 ALTER TABLE `Participante` DISABLE KEYS */;
INSERT INTO `Participante` VALUES (1,1,'EL','Pato','Donald','12345',300.00,50.00),(2,1,'El','Pato','Lucas','23456',400.00,400.00),(4,3,'Tom','y','Jerry','34567',350.00,100.00);
/*!40000 ALTER TABLE `Participante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Participante_Pago`
--

DROP TABLE IF EXISTS `Participante_Pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Participante_Pago` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDParticipante` int DEFAULT NULL,
  `IDCurso` int DEFAULT NULL,
  `Monto` decimal(12,2) DEFAULT NULL,
  `Fecha` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDParticipante` (`IDParticipante`),
  KEY `IDCurso` (`IDCurso`),
  CONSTRAINT `participante_pago_ibfk_1` FOREIGN KEY (`IDParticipante`) REFERENCES `Participante` (`ID`),
  CONSTRAINT `participante_pago_ibfk_2` FOREIGN KEY (`IDCurso`) REFERENCES `Curso` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Participante_Pago`
--

LOCK TABLES `Participante_Pago` WRITE;
/*!40000 ALTER TABLE `Participante_Pago` DISABLE KEYS */;
INSERT INTO `Participante_Pago` VALUES (1,1,1,50.00,'2023-05-24 17:38:35'),(2,2,1,100.00,'2023-05-24 17:38:35'),(3,2,1,100.00,'2023-05-24 17:38:35'),(4,2,1,200.00,'2023-05-24 17:38:35');
/*!40000 ALTER TABLE `Participante_Pago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Usuario`
--

DROP TABLE IF EXISTS `Usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Usuario` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `CorreoElectronico` varchar(100) DEFAULT NULL,
  `Paterno` varchar(50) DEFAULT NULL,
  `Materno` varchar(50) DEFAULT NULL,
  `Nombre` varchar(50) DEFAULT NULL,
  `Puesto` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Usuario`
--

LOCK TABLES `Usuario` WRITE;
/*!40000 ALTER TABLE `Usuario` DISABLE KEYS */;
INSERT INTO `Usuario` VALUES (1,'administrador@cursos.uv.mx','Administrador','','','Administrador');
/*!40000 ALTER TABLE `Usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-14 21:49:37
