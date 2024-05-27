-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 11, 2024 at 01:13 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `clinic-system`
--

-- --------------------------------------------------------

--
-- Table structure for table `appointment`
--

CREATE TABLE `appointment` (
  `Appid` int(50) NOT NULL,
  `docnumber` varchar(50) NOT NULL,
  `patnumber` varchar(50) NOT NULL,
  `date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`Appid`, `docnumber`, `patnumber`, `date`) VALUES
(1, '01000098305', '01060094330', '2024-05-08 22:58:25.476000'),
(3, '01000098305', '01060094330', '2024-05-08 22:59:30.174000'),
(4, '01000098305', '01060094330', '2024-05-08 22:59:30.174000'),
(5, '01000098305', '01060094330', '2024-05-08 22:59:30.174000'),
(6, '01000098305', '01060094330', '2024-05-08 22:59:30.174000'),
(7, '01000098305', '01060094330', '2024-05-08 22:59:30.174000'),
(8, '01000098305', '01060094330', '2024-05-08 22:59:30.174000'),
(9, '01000098305', '01060094330', '2024-05-08 22:59:30.174000');

-- --------------------------------------------------------

--
-- Table structure for table `diagnosis`
--

CREATE TABLE `diagnosis` (
  `diagid` int(11) NOT NULL,
  `pnumber` varchar(50) NOT NULL,
  `dnumber` varchar(50) NOT NULL,
  `description` mediumtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `diagnosis`
--

INSERT INTO `diagnosis` (`diagid`, `pnumber`, `dnumber`, `description`) VALUES
(1, '01016670600', '01286749530', 'yarab'),
(2, '01016670600', '01286749530', 'lol'),
(3, '01016670600', '01286749530', 'kok'),
(4, '01016670600', '01286749530', 'o2'),
(5, '01016670600', '01286749530', 'h20'),
(6, '01016670600', '01286749530', 'co2'),
(7, '01016670600', '01286749530', 'h2o2'),
(8, '01016670600', '01286749530', 'To diagnose long QT syndrome, a health care provider does a physical exam and asks questions about your symptoms and medical and family history. The health care provider uses a stethoscope to listen to your heart. If your provider thinks you have an irregular heartbeat, tests can be done to check the heart\'s rhythm.\r\n\r\nTests\r\nTests are done to confirm a diagnosis of long QT syndrome or check for other conditions that may affect the heart\'s rhythm or raise the risk of irregular heartbeats.'),
(9, '01016670600', '01286749530', '3ian'),
(10, '01016670600', '01286749530', 'test');

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `number` varchar(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `spec` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`number`, `name`, `spec`) VALUES
('01286749530', 'abdelrahman', 'neorolgy');

-- --------------------------------------------------------

--
-- Table structure for table `medication`
--

CREATE TABLE `medication` (
  `mid` int(11) NOT NULL,
  `dnumber` varchar(20) NOT NULL,
  `pnumber` varchar(20) NOT NULL,
  `description` mediumtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `medication`
--

INSERT INTO `medication` (`mid`, `dnumber`, `pnumber`, `description`) VALUES
(1, '01286749530', '01016670600', 'test'),
(2, '01286749530', '01016670600', 'test2'),
(3, '01286749530', '01016670600', 'nice'),
(4, '01286749530', '01016670600', '5od panadol'),
(5, '01286749530', '01016670600', '5od panadol tany'),
(6, '01286749530', '01016670600', 'test'),
(7, '01286749530', '01016670600', 'test 2'),
(8, '01286749530', '01016670600', 'testing');

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE `patient` (
  `number` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`number`, `name`) VALUES
('01016670600', 'samir');

-- --------------------------------------------------------

--
-- Table structure for table `treatment`
--

CREATE TABLE `treatment` (
  `tid` int(11) NOT NULL,
  `dnumber` varchar(20) NOT NULL,
  `pnumber` varchar(20) NOT NULL,
  `description` varchar(10000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `treatment`
--

INSERT INTO `treatment` (`tid`, `dnumber`, `pnumber`, `description`) VALUES
(1, '01286749530', '01016670600', 'X-ray'),
(2, '01286749530', '01016670600', 'MRI'),
(3, '01286749530', '01016670600', 'Chemotherapy, Radiotherapy'),
(4, '01286749530', '01016670600', 'Chemotherapy, Radiotherapy'),
(5, '01286749530', '01016670600', 'X-ray, MRI'),
(6, '01286749530', '01016670600', 'X-ray, MRI'),
(7, '01286749530', '01016670600', 'Chemotherapy, Radiotherapy'),
(8, '01286749530', '01016670600', 'X-ray, MRI'),
(9, '01286749530', '01016670600', 'panadol, amadol'),
(10, '01286749530', '01016670600', 'X-ray'),
(11, '01286749530', '01016670600', 'MRI'),
(12, '01286749530', '01016670600', 'MRI'),
(13, '01286749530', '01016670600', 'Radiotherapy'),
(14, '01286749530', '01016670600', 'Chemotherapy'),
(15, '01286749530', '01016670600', 'Chemotherapy'),
(16, '01286749530', '01016670600', 'bamm'),
(17, '01286749530', '01016670600', ''),
(18, '01286749530', '01016670600', 'test'),
(19, '01286749530', '01016670600', 'test123'),
(20, '01286749530', '01016670600', 'test123'),
(21, '01286749530', '01016670600', 'MRI'),
(22, '01286749530', '01016670600', 'test1234'),
(23, '01286749530', '01016670600', 'MRI'),
(24, '01286749530', '01016670600', 'Chemotherapy'),
(25, '01286749530', '01016670600', 'lol'),
(26, '01286749530', '01016670600', 'MRI'),
(27, '01286749530', '01016670600', 'hoh'),
(28, '01286749530', '01016670600', 'Radiotherapy'),
(29, '01286749530', '01016670600', 'MRI'),
(30, '01286749530', '01016670600', 'Chemotherapy'),
(31, '01286749530', '01016670600', 'lal'),
(32, '01286749530', '01016670600', 'Chemotherapy'),
(33, '01286749530', '01016670600', 'hja'),
(34, '01286749530', '01016670600', 'X-ray, MRI'),
(35, '01286749530', '01016670600', 'lalala'),
(36, '01286749530', '01016670600', 'X-ray, MRI'),
(37, '01286749530', '01016670600', 'testtt');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `diagnosis`
--
ALTER TABLE `diagnosis`
  ADD PRIMARY KEY (`diagid`),
  ADD KEY `pnumber` (`pnumber`),
  ADD KEY `dnumber` (`dnumber`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`number`);

--
-- Indexes for table `medication`
--
ALTER TABLE `medication`
  ADD PRIMARY KEY (`mid`),
  ADD KEY `dnumber` (`dnumber`),
  ADD KEY `pnumber` (`pnumber`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`number`);

--
-- Indexes for table `treatment`
--
ALTER TABLE `treatment`
  ADD PRIMARY KEY (`tid`),
  ADD KEY `dnumber` (`dnumber`),
  ADD KEY `pnumber` (`pnumber`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `diagnosis`
--
ALTER TABLE `diagnosis`
  MODIFY `diagid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `medication`
--
ALTER TABLE `medication`
  MODIFY `mid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `treatment`
--
ALTER TABLE `treatment`
  MODIFY `tid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `diagnosis`
--
ALTER TABLE `diagnosis`
  ADD CONSTRAINT `diagnosis_ibfk_1` FOREIGN KEY (`pnumber`) REFERENCES `patient` (`number`),
  ADD CONSTRAINT `diagnosis_ibfk_2` FOREIGN KEY (`dnumber`) REFERENCES `doctor` (`number`);

--
-- Constraints for table `medication`
--
ALTER TABLE `medication`
  ADD CONSTRAINT `medication_ibfk_1` FOREIGN KEY (`dnumber`) REFERENCES `doctor` (`number`),
  ADD CONSTRAINT `medication_ibfk_2` FOREIGN KEY (`pnumber`) REFERENCES `patient` (`number`);

--
-- Constraints for table `treatment`
--
ALTER TABLE `treatment`
  ADD CONSTRAINT `treatment_ibfk_1` FOREIGN KEY (`dnumber`) REFERENCES `doctor` (`number`),
  ADD CONSTRAINT `treatment_ibfk_2` FOREIGN KEY (`pnumber`) REFERENCES `patient` (`number`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
