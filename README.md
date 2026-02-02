# Top4-Question-
🧠 C# Practice Projects – Complete README
📌 Overview

This repository contains four C# console-based practice programs, each designed to strengthen core programming concepts such as exception handling, string manipulation, collections, unit testing, and object-oriented design.

These exercises simulate real-world scenarios like safety analysis, security-based string transformation, banking operations, and content creator engagement tracking.

🧩 Project List

Factory Robot Hazard Analyzer

ASCII Cleanse & Invert Utility

Bank Account – NUnit Test Cases

StreamBuzz Creator Engagement Tracker

🏭 1. Factory Robot Hazard Analyzer
🔹 Description

A safety analysis system that calculates a hazard risk score for factory robots based on:

Arm precision

Worker density

Machinery condition

Custom exceptions are used to handle invalid inputs.

🔧 Key Concepts Used

Custom Exceptions

Input Validation

Mathematical Computation

Exception Handling (try-catch)

📐 Formula
Hazard Risk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor)

⚠️ Machinery Risk Factors
State	Factor
Worn	1.3
Faulty	2.0
Critical	3.0
✅ Output

Displays hazard score if valid

Displays meaningful error messages if invalid

🔐 2. ASCII Cleanse & Invert Utility
🔹 Description

A string transformation tool that:

Filters characters based on ASCII values

Reverses the result

Applies position-based casing

This demonstrates how encoding-like transformations work.

🔄 Transformation Logic

Input must be at least 6 characters

Only alphabets allowed (no space, digit, special char)

Convert to lowercase

Remove characters with even ASCII values

Reverse remaining characters

Convert characters at even indices to uppercase

❌ Invalid Input Scenarios

Length < 6

Contains spaces

Contains digits

Contains special characters

✅ Output

Prints generated key

Prints Invalid Input if validation fails

🏦 3. Bank Account – NUnit Test Cases
🔹 Description

This project focuses on unit testing using NUnit for a bank account system that supports:

Deposit

Withdraw

🧪 Test Scenarios Covered
Test Case	Description
Valid Deposit	Balance increases correctly
Negative Deposit	Exception thrown
Valid Withdraw	Balance decreases correctly
Insufficient Funds	Exception thrown
📌 Rules Followed

One Assert per test method

Exact exception message validation

[TestFixture] and [Test] attributes used

🔧 Key Concepts Used

NUnit Framework

Exception Testing

Assertions

Test Design

📊 4. StreamBuzz Creator Engagement Tracker
🔹 Description

A menu-driven analytics system that tracks content creators’ engagement over 4 weeks.

📋 Features

Register creators with weekly likes

Identify top-performing creators using thresholds

Calculate overall average weekly likes

Graceful exit without Environment.Exit()

🧱 Data Structures Used

List<CreatorStats>

Dictionary<string, int>

Arrays

🧮 Calculations

Weekly threshold-based counts

Overall average likes across all creators
