-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 07-11-2024 a las 19:02:04
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `niños`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `musica`
--

CREATE TABLE `musica` (
  `id_musica` int(255) NOT NULL,
  `nombre_musica` varchar(60) NOT NULL,
  `contenido` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `musica_registro`
--

CREATE TABLE `musica_registro` (
  `id_musica_registro` int(255) NOT NULL,
  `id_registro` int(255) NOT NULL,
  `id_musica` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `registro`
--

CREATE TABLE `registro` (
  `id_registro` int(255) NOT NULL,
  `fecha` varchar(20) NOT NULL,
  `usuario` varchar(50) NOT NULL,
  `contraseña` varchar(50) NOT NULL,
  `sexo` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `registro`
--

INSERT INTO `registro` (`id_registro`, `fecha`, `usuario`, `contraseña`, `sexo`) VALUES
(1, '0000-00-00', 'Jose413', '0', 'MASCULINO'),
(2, 'miércoles, 3 de febr', 'Jose413', '0', 'MASCULINO'),
(3, 'miércoles, 3 de febr', 'Jose413', 'gfdjghfdjgdfgfdhjghdfjghdfjghjfdhjh', 'MASCULINO'),
(4, 'domingo, 7 de julio ', 'jose angel', 'fsdgfdg', 'MASCULINO'),
(5, 'miércoles, 3 de juli', 'jose', 'abc', 'MASCULINO'),
(6, 'domingo, 7 de julio ', 'carrasquero', '1', 'MASCULINO');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `musica`
--
ALTER TABLE `musica`
  ADD PRIMARY KEY (`id_musica`);

--
-- Indices de la tabla `musica_registro`
--
ALTER TABLE `musica_registro`
  ADD PRIMARY KEY (`id_musica_registro`),
  ADD UNIQUE KEY `id_registro` (`id_registro`),
  ADD UNIQUE KEY `id_musica` (`id_musica`);

--
-- Indices de la tabla `registro`
--
ALTER TABLE `registro`
  ADD PRIMARY KEY (`id_registro`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `musica`
--
ALTER TABLE `musica`
  MODIFY `id_musica` int(255) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `musica_registro`
--
ALTER TABLE `musica_registro`
  MODIFY `id_musica_registro` int(255) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `registro`
--
ALTER TABLE `registro`
  MODIFY `id_registro` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `musica_registro`
--
ALTER TABLE `musica_registro`
  ADD CONSTRAINT `musica_registro_ibfk_1` FOREIGN KEY (`id_registro`) REFERENCES `registro` (`id_registro`),
  ADD CONSTRAINT `musica_registro_ibfk_2` FOREIGN KEY (`id_musica`) REFERENCES `musica` (`id_musica`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
