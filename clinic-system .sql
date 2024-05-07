-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 06, 2024 at 10:13 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

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
(2, '01016670600', '01112554810', 'asads');

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `number` varchar(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `spec` varchar(100) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`number`, `name`, `spec`, `password`) VALUES
('01000098305', 'John', 'eyes', ''),
('01060094340', 'wagih', 'ears', ''),
('01112554810', 'seifoo', 'eye', '123'),
('01122558877', 'wegoo', 'bone', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `doctor_workdays`
--

CREATE TABLE `doctor_workdays` (
  `did` varchar(50) NOT NULL,
  `Wid` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctor_workdays`
--

INSERT INTO `doctor_workdays` (`did`, `Wid`) VALUES
('01000098305', 1),
('01000098305', 3),
('01000098305', 5);

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
('01016670600', 'seif'),
('01060094330', 'wigo'),
('0112939910102', 'samirrz');

-- --------------------------------------------------------

--
-- Table structure for table `workdays`
--

CREATE TABLE `workdays` (
  `Wid` int(50) NOT NULL,
  `Day` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `workdays`
--

INSERT INTO `workdays` (`Wid`, `Day`) VALUES
(1, 'Saturday'),
(2, 'Sunday'),
(3, 'Monday'),
(4, 'Tuesday'),
(5, 'Wednesday'),
(6, 'Thursday'),
(7, 'Friday');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appointment`
--
ALTER TABLE `appointment`
  ADD PRIMARY KEY (`Appid`),
  ADD KEY `docnumber` (`docnumber`),
  ADD KEY `patnumber` (`patnumber`);

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
-- Indexes for table `doctor_workdays`
--
ALTER TABLE `doctor_workdays`
  ADD KEY `did` (`did`),
  ADD KEY `Wid` (`Wid`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`number`);

--
-- Indexes for table `workdays`
--
ALTER TABLE `workdays`
  ADD PRIMARY KEY (`Wid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appointment`
--
ALTER TABLE `appointment`
  MODIFY `Appid` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `diagnosis`
--
ALTER TABLE `diagnosis`
  MODIFY `diagid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `workdays`
--
ALTER TABLE `workdays`
  MODIFY `Wid` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `appointment`
--
ALTER TABLE `appointment`
  ADD CONSTRAINT `appointment_ibfk_1` FOREIGN KEY (`docnumber`) REFERENCES `doctor` (`number`),
  ADD CONSTRAINT `appointment_ibfk_2` FOREIGN KEY (`patnumber`) REFERENCES `patient` (`number`);

--
-- Constraints for table `diagnosis`
--
ALTER TABLE `diagnosis`
  ADD CONSTRAINT `diagnosis_ibfk_1` FOREIGN KEY (`pnumber`) REFERENCES `patient` (`number`) ON DELETE CASCADE,
  ADD CONSTRAINT `diagnosis_ibfk_2` FOREIGN KEY (`dnumber`) REFERENCES `doctor` (`number`) ON DELETE CASCADE;

--
-- Constraints for table `doctor_workdays`
--
ALTER TABLE `doctor_workdays`
  ADD CONSTRAINT `doctor_workdays_ibfk_1` FOREIGN KEY (`did`) REFERENCES `doctor` (`number`),
  ADD CONSTRAINT `doctor_workdays_ibfk_2` FOREIGN KEY (`Wid`) REFERENCES `workdays` (`Wid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
