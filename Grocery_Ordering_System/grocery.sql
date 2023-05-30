-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 17, 2023 at 06:46 AM
-- Server version: 10.1.16-MariaDB
-- PHP Version: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `grocery`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_user`
--

CREATE TABLE `admin_user` (
  `user_id` int(5) NOT NULL,
  `password` int(5) NOT NULL,
  `Name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin_user`
--

INSERT INTO `admin_user` (`user_id`, `password`, `Name`) VALUES
(1, 1234, 'Kamal'),
(2, 12345, 'ajai');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `cus_id` int(5) NOT NULL,
  `cus_name` varchar(20) NOT NULL,
  `address` varchar(50) NOT NULL,
  `tell_no` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`cus_id`, `cus_name`, `address`, `tell_no`) VALUES
(1, 'Ajai', 'Colombo', 876543212),
(2, 'Kumar', 'Kandy', 2147483647),
(3, 'Raja', 'Trinco', 1234567892),
(4, 'Roja', 'Batti', 2147483647),
(5, 'Hari', 'Kandy', 2147483647),
(6, 'Rihnis', 'Maruthamunai', 754303288);

-- --------------------------------------------------------

--
-- Table structure for table `delivery`
--

CREATE TABLE `delivery` (
  `delivery` int(10) NOT NULL,
  `order_no` int(10) NOT NULL,
  `cus_id` int(5) NOT NULL,
  `cus_tell` int(10) NOT NULL,
  `del_address` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE `item` (
  `item_name` varchar(20) NOT NULL,
  `item_id` int(10) NOT NULL,
  `price` varchar(5) NOT NULL,
  `per` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `item`
--

INSERT INTO `item` (`item_name`, `item_id`, `price`, `per`) VALUES
('Basmati Rice', 1, '190', '1 KG'),
('Long Grain Rice', 2, '170', '1 KG'),
('Short Grain Rice', 3, '185', '1 KG'),
('Jasmine Rice', 4, '160', '1 KG'),
('Brown Rice', 5, '175', '1 KG'),
('Wild Rice', 6, '197', '1 KG'),
('Seeraga Samba Rice', 7, '155', '1 KG'),
('Potato', 8, '110', '1 KG'),
('Tomato', 9, '130', '1 KG'),
('Leak', 10, '170', '1 KG'),
('Cabbage', 11, '175', '1 KG'),
('Eggplant', 12, '145', '1 KG'),
('Moringa', 13, '120', '1 KG'),
('Chicken', 14, '1400', '1 KG'),
('Beef', 15, '1100', '1 KG'),
('Lamb', 16, '900', '1 KG'),
('Duck', 17, '1600', '1 KG'),
('Goose', 18, '750', '1 KG'),
('Pork', 19, '850', '1 KG'),
('Banana', 20, '90', '1 KG'),
('Grapes', 21, '150', '1 KG'),
('Orange', 22, '125', '1 KG'),
('Apple', 23, '110', '1 KG'),
('Mango', 24, '70', '1 KG'),
('Flore', 25, '250', '1 KG'),
('Vanilla', 26, '700', '10 ML'),
('Bakking Soda', 27, '940', '1 KG'),
('Good Day', 28, '240', '1'),
('Milk Biscuit', 29, '220', '1'),
('Oreo', 30, '300', '1'),
('Butter Biscuit', 31, '110', '1'),
('Unbic Biscuit', 32, '200', '1');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `order_no` int(5) NOT NULL,
  `cus_id` int(5) NOT NULL,
  `Date` varchar(20) NOT NULL,
  `item_name` varchar(20) NOT NULL,
  `price` int(7) NOT NULL,
  `quantity` int(5) NOT NULL,
  `total_price` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`order_no`, `cus_id`, `Date`, `item_name`, `price`, `quantity`, `total_price`) VALUES
(2, 1, '8/3/2022', 'Jasmine Rice', 160, 4, 640),
(3, 1, '8/3/2022', 'Brown Rice', 175, 6, 1050),
(4, 1, '8/3/2022', 'Brown Rice', 175, 1, 175),
(5, 1, '8/3/2022', 'Short Grain Rice', 185, 3, 555),
(6, 2, '8/4/2022', 'Short Grain Rice', 185, 3, 555),
(7, 2, '8/4/2022', 'Milk Biscuit', 220, 10, 2200),
(8, 1, '2/17/2023', 'Short Grain Rice', 185, 1, 185),
(9, 1, '2/17/2023', 'Basmati Rice', 190, 2, 380),
(10, 1, '2/17/2023', 'Jasmine Rice', 160, 4, 640),
(11, 1, '2/17/2023', 'Wild Rice', 197, 6, 1182);

-- --------------------------------------------------------

--
-- Table structure for table `ordertbl`
--

CREATE TABLE `ordertbl` (
  `order_no` int(10) NOT NULL,
  `cus_id` int(5) NOT NULL,
  `orders` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin_user`
--
ALTER TABLE `admin_user`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`cus_id`);

--
-- Indexes for table `delivery`
--
ALTER TABLE `delivery`
  ADD PRIMARY KEY (`delivery`),
  ADD KEY `cus_id` (`cus_id`),
  ADD KEY `order_no` (`order_no`);

--
-- Indexes for table `item`
--
ALTER TABLE `item`
  ADD PRIMARY KEY (`item_id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_no`);

--
-- Indexes for table `ordertbl`
--
ALTER TABLE `ordertbl`
  ADD PRIMARY KEY (`order_no`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `delivery`
--
ALTER TABLE `delivery`
  ADD CONSTRAINT `delivery_ibfk_1` FOREIGN KEY (`cus_id`) REFERENCES `customer` (`cus_id`),
  ADD CONSTRAINT `delivery_ibfk_2` FOREIGN KEY (`order_no`) REFERENCES `ordertbl` (`order_no`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
