/* 
 * One real-world application of the Abstract Factory design pattern in .NET is the creation of 
 * database providers. Let's consider an example where you have a data access layer that needs 
 * to work with different databases, such as SQL Server, Oracle, and MySQL. Here's how the 
 * Abstract Factory pattern can be applied:
 */

using System;

// Abstract Product: Database Connection
public interface IDatabaseConnection
{
	void Connect();
}

// Concrete Products: SQL Server, Oracle, and MySQL Connections
public class SqlConnection : IDatabaseConnection
{
	public void Connect()
	{
		Console.WriteLine("Connected to SQL Server database.");
	}
}

public class OracleConnection : IDatabaseConnection
{
	public void Connect()
	{
		Console.WriteLine("Connected to Oracle database.");
	}
}

public class MySqlConnection : IDatabaseConnection
{
	public void Connect()
	{
		Console.WriteLine("Connected to MySQL database.");
	}
}

// Abstract Factory: Database Factory
public interface IDatabaseFactory
{
	IDatabaseConnection CreateConnection();
}

// Concrete Factories: SQL Server, Oracle, and MySQL Factories
public class SqlDatabaseFactory : IDatabaseFactory
{
	public IDatabaseConnection CreateConnection()
	{
		return new SqlConnection();
	}
}

public class OracleDatabaseFactory : IDatabaseFactory
{
	public IDatabaseConnection CreateConnection()
	{
		return new OracleConnection();
	}
}

public class MySqlDatabaseFactory : IDatabaseFactory
{
	public IDatabaseConnection CreateConnection()
	{
		return new MySqlConnection();
	}
}

// Data Access Layer
public class DataAccessLayer
{
	private IDatabaseConnection connection;

	public DataAccessLayer(IDatabaseFactory factory)
	{
		connection = factory.CreateConnection();
	}

	public void ConnectToDatabase()
	{
		connection.Connect();
	}
}

// Usage
public class Program
{
	public static void Main()
	{
		// Create a SQL Server data access layer
		IDatabaseFactory sqlFactory = new SqlDatabaseFactory();
		DataAccessLayer sqlDataAccessLayer = new DataAccessLayer(sqlFactory);
		sqlDataAccessLayer.ConnectToDatabase();

		// Create an Oracle data access layer
		IDatabaseFactory oracleFactory = new OracleDatabaseFactory();
		DataAccessLayer oracleDataAccessLayer = new DataAccessLayer(oracleFactory);
		oracleDataAccessLayer.ConnectToDatabase();

		// Create a MySQL data access layer
		IDatabaseFactory mysqlFactory = new MySqlDatabaseFactory();
		DataAccessLayer mysqlDataAccessLayer = new DataAccessLayer(mysqlFactory);
		mysqlDataAccessLayer.ConnectToDatabase();
	}
}

/*
In this example, we have a data access layer that needs to connect to different databases. 
The IDatabaseConnection interface defines the common operations for connecting to a database.

The SqlConnection, OracleConnection, and MySqlConnection classes are concrete implementations 
of the IDatabaseConnection interface, representing connections to SQL Server, Oracle, and MySQL 
databases respectively.

The IDatabaseFactory interface declares the abstract factory method CreateConnection(). 
The SqlDatabaseFactory, OracleDatabaseFactory, and MySqlDatabaseFactory classes implement 
this interface to provide concrete implementations of the factory method, creating instances 
of the appropriate database connection classes.

The DataAccessLayer class represents the data access layer that requires a database connection. 
It takes an instance of the abstract factory in its constructor and uses it to create the 
appropriate database connection instance. The ConnectToDatabase() method demonstrates how the 
data access layer can connect to the database using the created connection object.

In the Main method, we create three instances of the data access layer, each with a different 
concrete factory (SqlDatabaseFactory, OracleDatabaseFactory, and MySqlDatabaseFactory). 
Each instance connects to the respective database using the appropriate database connection object.

This example shows how the Abstract Factory pattern can be used to create database connections 
for different database providers in a flexible and modular way. It allows the data access layer to 
work with different databases by simply changing the concrete factory implementation without 
modifying the core data access logic.
*/