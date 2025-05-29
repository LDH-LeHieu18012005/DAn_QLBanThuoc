Pharmacy Management System
A C# WinForms application for streamlined pharmacy operations, including inventory management, sales, purchases, and AI-powered stroke risk prediction. Built with SQL Server for robust data storage and integrated with a Machine Learning model via Flask API.
Introduction
The Pharmacy Management System is a comprehensive solution for pharmacies to manage medicines, suppliers, customers, and financial operations. Key features include inventory control, invoice management, revenue analytics, and health risk prediction using AI, ideal for small to medium-sized pharmacies.
Technologies Used

Language: C# (.NET Framework)
UI Framework: Windows Forms (WinForms)
Database: SQL Server
AI Integration: Python Flask API with Machine Learning model for stroke prediction
Libraries:
Newtonsoft.Json for JSON handling
System.Net.Http for API communication
ZXing.Net for barcode/QR code scanning
iTextSharp for PDF generation
AForge.Video for webcam integration
System.Windows.Forms.DataVisualization for charting



Key Features

Medicine Management: Add, edit, delete, and search medicines with real-time stock updates.
Customer & Supplier Management: Maintain detailed records for customers and suppliers.
Invoice Management: Create, view, edit, and delete purchase/sales invoices with validation.
Advanced Analytics: Visualize monthly/yearly revenue, profit, and top-selling medicines via charts.
Expiration Tracking: Calculate profits excluding expired drugs.
Barcode Scanning: Scan medicine barcodes using a webcam for quick sales processing.
Stroke Risk Prediction: Predict stroke risk based on health metrics (age, BMI, glucose, etc.).
PDF Reporting: Export sales invoices as PDF files.
Password Recovery: Secure OTP-based password reset via email.

Screenshots



Dashboard
Sales Management
Stroke Prediction








Replace the placeholder image paths above with actual screenshots of your application.
Getting Started
Prerequisites

.NET Framework (version 4.7.2 or higher)
SQL Server (configured with the provided database schema)
Python (for running the Flask API)
Webcam (for barcode scanning)
SMTP Credentials (e.g., Gmail App Password for OTP emails)

Installation

Clone the repository:git clone https://github.com/LDH-LeHieu18012005/DAn_QLBanThuoc.git


Set up the database:
Restore the SQL Server database using the provided DAn_1_QLBanThuoc.bak file.
Update the connection string in all forms (e.g., Data Source=LEHIEU\LEHIEU;Initial Catalog=DAn_1_QLBanThuoc;Integrated Security=True;TrustServerCertificate=True).


Install dependencies:
Ensure NuGet packages (Newtonsoft.Json, ZXing.Net, iTextSharp, AForge.Video) are installed.


Run the Flask API (for stroke prediction):cd ai-model
pip install -r requirements.txt
python app.py

Ensure the API runs at http://127.0.0.1:5000/predict.
Configure SMTP:
Update the email and App Password in forgot_password.cs for OTP functionality.


Build and run:
Open the solution in Visual Studio, build, and run the application.



Usage

Login: Use credentials from the Staff table or recover password via OTP.
Dashboard: View metrics (customers, medicines, revenue, profit) and charts.
Manage Inventory: Add/edit medicines, suppliers, and customers.
Process Transactions: Create purchase/sales invoices with barcode scanning support.
Analyze Data: Generate revenue/profit reports by month, quarter, or year.
Predict Health Risks: Input customer health data to predict stroke risk.
Export Invoices: Save sales invoices as PDFs.

Error Handling

Validates input data (e.g., positive quantities, valid dates, matching passwords).
Displays clear error messages for invalid inputs or failed operations.
Logs errors during PDF generation and email sending.
Ensures stock availability before creating sales invoices.

Why This Project Stands Out

Modern Features: Barcode scanning and AI-powered stroke prediction.
User-Friendly: Intuitive WinForms interface with real-time updates and analytics.
Secure: OTP-based password recovery.
Scalable: Modular design with SQL Server backend.

Contributing
To contribute:

Fork the repository.
Create a feature branch (git checkout -b feature/YourFeature).
Commit your changes (git commit -m 'Add YourFeature').
Push to the branch (git push origin feature/YourFeature).
Open a Pull Request.

Contact
For questions or feedback:

GitHub: LDH-LeHieu18012005
Email: duonghieulehy@gmail.com, hieuleduonghy@gmail.com

License
This project is licensed under the MIT License. See the LICENSE file for details.
Built by Le Hieu for efficient pharmacy management and innovative health solutions.
