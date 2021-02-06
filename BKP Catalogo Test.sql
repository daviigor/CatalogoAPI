/*
SQLyog Ultimate v13.1.1 (64 bit)
MySQL - 10.4.14-MariaDB-log : Database - catalogo
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`catalogo` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `catalogo`;

/*Table structure for table `__efmigrationshistory` */

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `__efmigrationshistory` */

insert  into `__efmigrationshistory`(`MigrationId`,`ProductVersion`) values 
('20210124234723_DBInit','5.0.0');

/*Table structure for table `categoria` */

DROP TABLE IF EXISTS `categoria`;

CREATE TABLE `categoria` (
  `IdCategoria` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `IdCategoriaPai` int(11) NOT NULL,
  `Ativo` bit(1) NOT NULL,
  PRIMARY KEY (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

/*Data for the table `categoria` */

insert  into `categoria`(`IdCategoria`,`Nome`,`IdCategoriaPai`,`Ativo`) values 
(2,'categoria 2',10,''),
(10,'adfg',13,''),
(12,'adfgxxxxxxxxxxxxxxx',2,''),
(13,'adfgxxxxxxxx',0,''),
(14,'CATEGORIA NOVA',2,'');

/*Table structure for table `produto` */

DROP TABLE IF EXISTS `produto`;

CREATE TABLE `produto` (
  `IdProduto` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `Descricao` varchar(3000) DEFAULT NULL,
  `IdCategoria` int(11) DEFAULT NULL,
  `Ativo` bit(1) NOT NULL,
  `Estoque` int(11) NOT NULL,
  `Preco` decimal(65,2) NOT NULL,
  `ImagemURL` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`IdProduto`),
  KEY `IX_produto_IdCategoria` (`IdCategoria`),
  CONSTRAINT `fk_produto_categoria` FOREIGN KEY (`IdCategoria`) REFERENCES `categoria` (`IdCategoria`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `produto` */

insert  into `produto`(`IdProduto`,`Nome`,`Descricao`,`IdCategoria`,`Ativo`,`Estoque`,`Preco`,`ImagemURL`) values 
(1,'produto testekk','produto teste produto teste produto teste produto teste ',NULL,'\0',599,3.14,'https://23103.cdn.simplo7.net/static/23103/sku/mecanica-produto-teste-nao-comprar--p-1533242083167.jpg'),
(2,'produto teste2 aaa','produto teste produto teste produto teste produto teste 222222',10,'',599,373.37,'https://23103.cdn.simplo7.net/static/23103/sku/mecanica-produto-teste-nao-comprar--p-1533242083167.jpg');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
