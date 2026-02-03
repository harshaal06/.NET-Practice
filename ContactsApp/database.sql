-- Create database
CREATE DATABASE IF NOT EXISTS ContactsDB;

-- Use the database
USE ContactsDB;

-- Create Contacts table
CREATE TABLE IF NOT EXISTS Contacts (
  Id INT AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(100) NOT NULL,
  PhoneNumber VARCHAR(15) NOT NULL
);
