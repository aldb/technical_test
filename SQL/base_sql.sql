-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : sam. 05 fév. 2022 à 18:01
-- Version du serveur : 5.7.36
-- Version de PHP : 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `test_technique_unity`
--

-- --------------------------------------------------------

--
-- Structure de la table `gamesave`
--

DROP TABLE IF EXISTS `gamesave`;
CREATE TABLE IF NOT EXISTS `gamesave` (
  `id` varchar(6) NOT NULL,
  `lvlClickCollect` int(11) NOT NULL DEFAULT '0',
  `lvlAutoCollect` int(11) NOT NULL DEFAULT '0',
  `tilesID` binary(13) DEFAULT NULL,
  `ressources` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `tilesID` (`tilesID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `tile`
--

DROP TABLE IF EXISTS `tile`;
CREATE TABLE IF NOT EXISTS `tile` (
  `tileID` binary(13) NOT NULL,
  `cat` tinyint(1) NOT NULL,
  `coordX` int(11) NOT NULL,
  `coordY` int(11) NOT NULL,
  `tilesId` binary(13) DEFAULT NULL,
  PRIMARY KEY (`tileID`),
  KEY `tilesId` (`tilesId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
