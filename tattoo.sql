-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 13-Set-2021 às 03:36
-- Versão do servidor: 10.4.20-MariaDB
-- versão do PHP: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `tattoo`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `pedido`
--

CREATE TABLE `pedido` (
  `idPedido` int(11) NOT NULL,
  `nomePedido` varchar(100) NOT NULL,
  `ideiaPedido` text NOT NULL,
  `localPedido` varchar(100) NOT NULL,
  `tamanhoPedido` varchar(20) NOT NULL,
  `dataPedido` varchar(20) NOT NULL,
  `valorPedido` int(10) NOT NULL,
  `statusPedido` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `pedido`
--

INSERT INTO `pedido` (`idPedido`, `nomePedido`, `ideiaPedido`, `localPedido`, `tamanhoPedido`, `dataPedido`, `valorPedido`, `statusPedido`) VALUES
(1, 'Felipe Machado', 'Bob Marley', 'Braço', ' 8 x 40', '23/11/2021 15:00', 850, 'Desenhando'),
(3, 'Paola', 'Unicórnio', 'Bunda', '10 x 30', '23/07/2022 13:30', 980, ''),
(4, 'Chuck Norris', 'Dragão', 'Testa', '25 x 30', '25/12/2022 13:35', 1250, 'Desenhando');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `pedido`
--
ALTER TABLE `pedido`
  ADD PRIMARY KEY (`idPedido`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `pedido`
--
ALTER TABLE `pedido`
  MODIFY `idPedido` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
