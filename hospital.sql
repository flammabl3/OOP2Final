-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 14, 2024 at 04:49 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hospital`
--

-- --------------------------------------------------------

--
-- Table structure for table `bed`
--

CREATE TABLE `bed` (
  `bed_number` int(3) NOT NULL,
  `patient_number` int(8) DEFAULT NULL,
  `room_number` int(4) NOT NULL,
  `ward_letter` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bed`
--

INSERT INTO `bed` (`bed_number`, `patient_number`, `room_number`, `ward_letter`) VALUES
(1, NULL, 3001, 'C'),
(3, NULL, 1001, 'A'),
(5, NULL, 1001, 'A'),
(7, NULL, 1001, 'A'),
(1, 12345678, 1001, 'A'),
(4, 17010713, 1001, 'A'),
(6, 43145825, 1001, 'A'),
(2, 96860548, 1001, 'A');

-- --------------------------------------------------------

--
-- Table structure for table `medical_staff`
--

CREATE TABLE `medical_staff` (
  `staff_id` int(9) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `contact_number` varchar(16) NOT NULL,
  `contact_email` varchar(255) NOT NULL,
  `title` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `medical_staff`
--

INSERT INTO `medical_staff` (`staff_id`, `first_name`, `last_name`, `contact_number`, `contact_email`, `title`) VALUES
(123456789, 'John', 'Doe', '1112223333', 'jd@health.net', 'N'),
(478429344, 'Jimmy', 'Doohan', '2131241241', 'HJ@health.net', 'D'),
(934334928, 'Beverley', 'Crusher', '2131315556', 'BCrusher@enterprise.fed', 'D'),
(987654321, 'Jane', 'Doe', '9995554321', 'JaneD@health.net', 'D');

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE `patient` (
  `patient_number` int(11) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `middle_name` varchar(100) DEFAULT NULL,
  `last_name` varchar(100) NOT NULL,
  `contact_number` varchar(16) NOT NULL,
  `admission_date` date NOT NULL DEFAULT current_timestamp(),
  `discharge_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`patient_number`, `first_name`, `middle_name`, `last_name`, `contact_number`, `admission_date`, `discharge_date`) VALUES
(12345678, 'Harry', 'Jabi', 'Jung', '4035555555', '2024-07-17', NULL),
(13998382, 'Jimmy', NULL, 'Muller', '4039991234', '2024-07-01', '2024-08-13'),
(17010713, 'Jean-Luc', NULL, 'Picard', '5555555555', '2024-08-06', NULL),
(41725146, 'John', NULL, 'Doe', '0987231134', '2024-02-06', '2024-08-13'),
(43145825, 'James', 'Tiberius', 'Kirk', '1234567890', '2024-08-12', NULL),
(78716824, 'Steven', NULL, 'Mbeki', '2132145551', '2024-08-13', NULL),
(96860548, 'Geordi', NULL, 'LaForge', '0231903194', '2024-08-12', '2024-08-12');

-- --------------------------------------------------------

--
-- Table structure for table `procedure`
--

CREATE TABLE `procedure` (
  `procedure_id` int(9) NOT NULL,
  `procedure_name` varchar(20) NOT NULL,
  `patient_number` int(9) NOT NULL,
  `operating_staff_id` int(9) NOT NULL,
  `date_performed` date DEFAULT NULL,
  `date_scheduled` date NOT NULL,
  `procedure_type` char(1) NOT NULL,
  `room_number` int(4) DEFAULT NULL,
  `ward_letter` char(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `procedure`
--

INSERT INTO `procedure` (`procedure_id`, `procedure_name`, `patient_number`, `operating_staff_id`, `date_performed`, `date_scheduled`, `procedure_type`, `room_number`, `ward_letter`) VALUES
(208497798, 'Foot Washing', 12345678, 123456789, NULL, '2024-08-13', 'C', NULL, NULL),
(240772572, 'Brain Removal', 13998382, 934334928, '2024-08-13', '2024-08-16', 'S', 2001, 'B'),
(434586914, 'Food Delivery', 12345678, 123456789, '2024-08-12', '2024-08-11', 'C', NULL, NULL),
(464975852, 'Brain Removal', 96860548, 934334928, NULL, '2024-08-13', 'S', 1002, 'A'),
(567403024, 'Food Delivery', 78716824, 123456789, NULL, '2024-08-13', 'C', NULL, NULL),
(610180379, 'Kidney Surgery', 12345678, 987654321, '2024-08-13', '2024-08-11', 'S', 1002, 'A'),
(867841050, 'Brain Removal', 96860548, 934334928, NULL, '2024-08-13', 'S', 1002, 'A'),
(892593331, 'Food Delivery', 96860548, 123456789, NULL, '2024-08-24', 'C', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `room_number` int(4) NOT NULL,
  `ward_letter` char(1) NOT NULL,
  `room_name` varchar(20) NOT NULL,
  `room_type` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`room_number`, `ward_letter`, `room_name`, `room_type`) VALUES
(1001, 'A', 'Patient Room 1', 'P'),
(1002, 'A', 'Operating Room 1', 'M'),
(2001, 'B', 'Respiratory Surgery ', 'M'),
(3001, 'C', 'Pediatrics Care 1', 'P');

-- --------------------------------------------------------

--
-- Table structure for table `ward`
--

CREATE TABLE `ward` (
  `ward_letter` char(1) NOT NULL,
  `ward_name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ward`
--

INSERT INTO `ward` (`ward_letter`, `ward_name`) VALUES
('A', 'Standard Ward'),
('B', 'Respiratory'),
('C', 'Pediatrics');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bed`
--
ALTER TABLE `bed`
  ADD PRIMARY KEY (`bed_number`,`room_number`,`ward_letter`),
  ADD KEY `bed_patient_number_fk` (`patient_number`),
  ADD KEY `bed_ward_letter_fk` (`ward_letter`),
  ADD KEY `bed_room_number_fk` (`room_number`);

--
-- Indexes for table `medical_staff`
--
ALTER TABLE `medical_staff`
  ADD PRIMARY KEY (`staff_id`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`patient_number`);

--
-- Indexes for table `procedure`
--
ALTER TABLE `procedure`
  ADD PRIMARY KEY (`procedure_id`),
  ADD KEY `procedure_ward_letter_fk` (`ward_letter`),
  ADD KEY `procedure_room_number_fk` (`room_number`),
  ADD KEY `procedure_operating_staff_id_fk` (`operating_staff_id`),
  ADD KEY `procedure_patient_number_fk` (`patient_number`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`room_number`,`ward_letter`),
  ADD KEY `room_ward_letter_fk` (`ward_letter`);

--
-- Indexes for table `ward`
--
ALTER TABLE `ward`
  ADD PRIMARY KEY (`ward_letter`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bed`
--
ALTER TABLE `bed`
  ADD CONSTRAINT `bed_patient_number_fk` FOREIGN KEY (`patient_number`) REFERENCES `patient` (`patient_number`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bed_room_number_fk` FOREIGN KEY (`room_number`) REFERENCES `room` (`room_number`),
  ADD CONSTRAINT `bed_ward_letter_fk` FOREIGN KEY (`ward_letter`) REFERENCES `room` (`ward_letter`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `procedure`
--
ALTER TABLE `procedure`
  ADD CONSTRAINT `procedure_operating_staff_id_fk` FOREIGN KEY (`operating_staff_id`) REFERENCES `medical_staff` (`staff_id`),
  ADD CONSTRAINT `procedure_patient_number_fk` FOREIGN KEY (`patient_number`) REFERENCES `patient` (`patient_number`),
  ADD CONSTRAINT `procedure_room_number_fk` FOREIGN KEY (`room_number`) REFERENCES `room` (`room_number`),
  ADD CONSTRAINT `procedure_ward_letter_fk` FOREIGN KEY (`ward_letter`) REFERENCES `room` (`ward_letter`);

--
-- Constraints for table `room`
--
ALTER TABLE `room`
  ADD CONSTRAINT `room_ward_letter_fk` FOREIGN KEY (`ward_letter`) REFERENCES `ward` (`ward_letter`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
