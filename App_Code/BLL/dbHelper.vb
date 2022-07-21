Imports System
Imports System.Data
Imports System.Data.Common

Public Class dbHelper

    Private Shared _factory As Providers = Providers.SqlClient
    Private Shared _connectionString As String = ConfigurationManager.ConnectionStrings("ShaahrConnectionString").ConnectionString

    ''' <summary>
    ''' Get or Sets the Connection String
    ''' </summary>
    ''' <value></value>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Shared Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
        Set(ByVal value As String)
            _connectionString = value
        End Set
    End Property

    ''' <summary>
    ''' Get Factory By Provider
    ''' </summary>
    ''' <param name="oGetFactory"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetFactoryByProvider(ByVal oGetFactory As Providers) As String
        Select Case CType(oGetFactory, Providers)
            Case Providers.Odbc
                Return "System.Data.Odbc"

            Case Providers.OleDb
                Return "System.Data.OleDb"

            Case Providers.SqlClient
                Return "System.Data.SqlClient"

            Case Providers.OracleClient
                Return "System.Data.OracleClient"

            Case Providers.MySql
                Return "CorLab.MySql.MySqlClient"
        End Select
        Return ""
    End Function

    ''' <summary>
    ''' Creates a new instance of a System.Data.Commom.dbParameter object.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="type"></param>
    ''' <param name="value"></param>
    ''' <returns>A System.Data.Commom.dbParameter object</returns>
    ''' <remarks></remarks>
    Public Shared Function CreateParameter(ByVal name As String, ByVal type As DbType, ByVal value As Object) As IDataParameter
        Return CreateParameter(name, type, value, ParameterDirection.Input)
    End Function

    ''' <summary>
    ''' Creates a new instance of a System.Data.Commom.dbParameter object.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="type"></param>
    ''' <param name="value"></param>
    ''' <param name="direction"></param>
    ''' <returns>A System.Data.Commom.dbParameter object</returns>
    ''' <remarks></remarks>
    Public Shared Function CreateParameter(ByVal name As String, ByVal type As DbType, ByVal value As Object, ByVal direction As ParameterDirection) As IDataParameter

        Dim param As DbParameter = Nothing

        Dim oProviderFactory As DbProviderFactory = DbProviderFactories.GetFactory(GetFactoryByProvider(_factory))
        Dim Con As DbConnection = oProviderFactory.CreateConnection
        Dim cmd As DbCommand = Con.CreateCommand

        param = cmd.CreateParameter()

        If Not param Is Nothing Then
            param.ParameterName = name
            param.DbType = type
            param.Direction = direction
            param.Value = value
        End If

        Return param
    End Function

    ''' <summary>
    ''' Executes a Transact-SQL statement against the connection and returns the number of rows affected.
    ''' </summary>
    ''' <param name="cmdType">Set the Transact-SQL statement or stored procedure to execute at the data source.</param>
    ''' <param name="cmdText">The text of the query.</param>
    ''' <returns></returns>
    ''' <remarks>The number of rows affected.</remarks>
    Public Shared Function ExecuteNonQuery(ByVal cmdType As CommandType, ByVal cmdText As String) As Integer
        Return ExecuteNonQuery(cmdType, cmdText, Nothing)
    End Function

    ''' <summary>
    ''' Executes a Transact-SQL statement against the connection and returns the number of rows affected.
    ''' </summary>
    ''' <param name="cmdType">Set the Transact-SQL statement or stored procedure to execute at the data source.</param>
    ''' <param name="cmdText">The text of the query.</param>
    ''' <param name="cmdParms">Set Array of Parameter</param>
    ''' <returns>The number of rows affected.</returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteNonQuery(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As DbParameter()) As Integer

        Dim oProviderFactory As DbProviderFactory = DbProviderFactories.GetFactory(GetFactoryByProvider(_factory))
        Dim Con As DbConnection = oProviderFactory.CreateConnection
        Dim cmd As DbCommand = Con.CreateCommand
        Dim trans As DbTransaction = Nothing

        Try
            Con.ConnectionString = ConnectionString
            cmd.Connection = Con
            cmd.CommandText = cmdText
            cmd.Parameters.Clear()
            cmd.CommandType = cmdType

            If Not (IsNothing(cmdParms)) Then
                Dim param As DbParameter

                'MsgBox(cmdParms.Length)
                'MsgBox(cmdParms(0).ParameterName & " " & cmdParms(0).Value)
                'MsgBox(cmdParms(1).ParameterName & " " & cmdParms(1).Value)

                For Each param In cmdParms
                    If Not IsNothing(param) Then
                        cmd.Parameters.Add(param)
                    End If

                Next
            End If

            Con.Open()
            trans = Con.BeginTransaction
            cmd.Transaction = trans
            Dim val As Integer = cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            trans.Commit()
            Return val

        Catch ex As DbException
            trans.Rollback()
            Throw New Exception("DB Exception " & ex.Message)

        Catch exx As Exception
            MsgBox(exx.ToString())
            trans.Rollback()
            Throw New Exception("ExecuteNonQuery Function", exx)
        Finally
            Con.Close()
            cmd = Nothing
            cmdParms = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Executes the query, and returns the first column of the first row in the result set returned by the query.
    ''' </summary>
    ''' <param name="cmdType">Set the Transact-SQL statement or stored procedure to execute at the data source.</param>
    ''' <param name="cmdText">The text of the query.</param>
    ''' <returns></returns>
    ''' <remarks>The first column of the first row in the result set, or a null reference if the result set is empty.</remarks>
    Public Shared Function ExecuteScalar(ByVal cmdType As CommandType, ByVal cmdText As String) As Object
        Return ExecuteScalar(cmdType, cmdText, Nothing)
    End Function

    ''' <summary>
    ''' Executes the query, and returns the first column of the first row in the result set returned by the query.
    ''' </summary>
    ''' <param name="cmdType">Set the Transact-SQL statement or stored procedure to execute at the data source.</param>
    ''' <param name="cmdText">The text of the query.</param>
    ''' <param name="cmdParms">Set Array of Parameter</param>
    ''' <returns></returns>
    ''' <remarks>The first column of the first row in the result set, or a null reference if the result set is empty.</remarks>
    Public Shared Function ExecuteScalar(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As DbParameter()) As Object

        Dim oProviderFactory As DbProviderFactory = DbProviderFactories.GetFactory(GetFactoryByProvider(_factory))
        Dim Con As DbConnection = oProviderFactory.CreateConnection
        Dim cmd As DbCommand = Con.CreateCommand
        Dim trans As DbTransaction = Nothing

        Try
            Con.ConnectionString = ConnectionString
            cmd.Connection = Con
            cmd.CommandText = cmdText
            cmd.Parameters.Clear()
            cmd.CommandType = cmdType

            If Not (IsNothing(cmdParms)) Then
                Dim param As DbParameter

                For Each param In cmdParms
                    cmd.Parameters.Add(param)
                Next
            End If

            Con.Open()
            trans = Con.BeginTransaction
            cmd.Transaction = trans

            Dim val As Object = cmd.ExecuteScalar()
            cmd.Parameters.Clear()
            trans.Commit()
            Return val

        Catch ex As DbException
            trans.Rollback()
            Throw New Exception("DB Exception " & ex.Message)

        Catch exx As Exception
            trans.Rollback()
            Throw New Exception("ExecuteNonQuery Function", exx)
        Finally
            Con.Close()
            cmd = Nothing
            cmdParms = Nothing
        End Try
    End Function

    ''' <summary>
    ''' ExecuteTable Return DataTable
    ''' </summary>
    ''' <param name="cmdType">The command Type</param>
    ''' <param name="cmdText">The command text to execute</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteTable(ByVal cmdType As CommandType, ByVal cmdText As String) As DataTable
        Return ExecuteTable(cmdType, cmdText, Nothing)
    End Function

    ''' <summary>
    ''' ExecuteTable Return DataTable
    ''' </summary>
    ''' <param name="cmdType">The command Type</param>
    ''' <param name="cmdText">The command text to execute</param>
    ''' <param name="cmdParms">Array of Parameters</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteTable(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As DbParameter()) As DataTable
        Dim oProviderFactory As DbProviderFactory = DbProviderFactories.GetFactory(GetFactoryByProvider(_factory))
        Dim oDataAdapter As DbDataAdapter
        Dim Con As DbConnection = oProviderFactory.CreateConnection
        Dim cmd As DbCommand
        Try
            Con.ConnectionString = ConnectionString
            cmd = Con.CreateCommand
            PrepareCommand(cmd, Con, cmdType, cmdText, cmdParms)
            oDataAdapter = oProviderFactory.CreateDataAdapter
            Dim oDataTable As New DataTable
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            Return oDataTable
        Catch ex As DbException
            Throw New Exception("DB Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteTable Exception :", exx)
        Finally
            Con.Close()
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    ''' <summary>
    ''' <para>Executes the <paramref name="commandText"/> as part of the given <paramref name="transaction" /> and returns the results in a new <see cref="DataSet"/>.</para>
    ''' </summary>
    ''' <param name="cmdType"></param>
    ''' <param name="cmdText">The command text to execute.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteDataSet(ByVal cmdType As CommandType, ByVal cmdText As String) As DataSet
        Return ExecuteDataSet(cmdType, cmdText, Nothing)
    End Function

    ''' <summary>
    ''' <para>Executes the <paramref name="commandText"/> as part of the given <paramref name="transaction" /> and returns the results in a new <see cref="DataSet"/>.</para>
    ''' </summary>
    ''' <param name="cmdType">One of the <see cref="CommandType"/> values.</param>
    ''' <param name="cmdText">The command text to execute.</param>
    ''' <param name="cmdParms"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteDataSet(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As DbParameter()) As DataSet
        Dim oProviderFactory As DbProviderFactory = DbProviderFactories.GetFactory(GetFactoryByProvider(_factory))
        Dim con As DbConnection = oProviderFactory.CreateConnection
        Dim oDataAdapter As DbDataAdapter = oProviderFactory.CreateDataAdapter
        Dim cmd As DbCommand = con.CreateCommand

        Try
            con.ConnectionString = ConnectionString
            cmd = con.CreateCommand
            PrepareCommand(cmd, con, cmdType, cmdText, cmdParms)
            oDataAdapter = oProviderFactory.CreateDataAdapter
            Dim oDataSet As New DataSet
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataSet)
            cmd.Parameters.Clear()

            Return oDataSet

        Catch ex As DbException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("Execute DataSet", exx)
        Finally
            con.Close()
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Sends the System.Data.Common.DbCommand.CommandText to the System.Data.Common.DbCommand.Connection and builds a System.Data.Common.DbDataReader.
    ''' </summary>
    ''' <param name="conn">A System.Data.Common.DbConnection that represents the connection to an instance of DataSource.</param>
    ''' <param name="cmdType">Set the Transact-SQL statement or stored procedure to execute at the data source.</param>
    ''' <param name="cmdText">The text of the query.</param>
    ''' <returns>A System.Data.Common.DbDataReader object.</returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteReader(ByRef conn As DbConnection, ByVal cmdType As CommandType, ByVal cmdText As String) As DbDataReader
        Return ExecuteReader(conn, cmdType, cmdText, Nothing)
    End Function

    ''' <summary>
    ''' Sends the System.Data.Common.DbCommand.CommandText to the System.Data.Common.DbCommand.Connection and builds a System.Data.Common.DbDataReader.
    ''' </summary>
    ''' <param name="conn">A System.Data.Common.DbConnection that represents the connection to an instance of DataSource.</param>
    ''' <param name="cmdType">Set the Transact-SQL statement or stored procedure to execute at the data source.</param>
    ''' <param name="cmdText">The text of the query.</param>
    ''' <param name="cmdParms">Set Array of Parameter</param>
    ''' <returns>A System.Data.Common.DbDataReader object.</returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteReader(ByRef conn As DbConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As DbParameter()) As DbDataReader

        Dim oProviderFactory As DbProviderFactory = DbProviderFactories.GetFactory(GetFactoryByProvider(_factory))
        conn = oProviderFactory.CreateConnection

        Dim oDataAdapter As DbDataAdapter = oProviderFactory.CreateDataAdapter
        Dim cmd As DbCommand = conn.CreateCommand

        Dim rdr As DbDataReader

        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            rdr = cmd.ExecuteReader()
            cmd.Parameters.Clear()

            If Not (IsNothing(cmdParms)) Then
                Dim param As DbParameter

                For Each param In cmdParms
                    cmd.Parameters.Add(param)
                Next
            End If

            Return rdr

        Catch ex As DbException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteReader", exx)
        Finally
            cmd = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cmdType"></param>
    ''' <param name="cmdText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteRow(ByVal cmdType As CommandType, ByVal cmdText As String) As DataRow
        Return ExecuteRow(cmdType, cmdText, Nothing)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cmdType"></param>
    ''' <param name="cmdText"></param>
    ''' <param name="cmdParms"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteRow(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As DbParameter()) As DataRow
        Dim oProviderFactory As DbProviderFactory = DbProviderFactories.GetFactory(GetFactoryByProvider(_factory))
        Dim Con As DbConnection = oProviderFactory.CreateConnection
        Con.ConnectionString = ConnectionString
        Dim cmd As DbCommand = Con.CreateCommand
        Dim oDataAdapter As DbDataAdapter = oProviderFactory.CreateDataAdapter
        Dim oDataRow As DataRow = Nothing
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, Con, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            If oDataTable.Rows.Count = 0 Then
                Return Nothing
            Else
                Dim oRow As DataRow = oDataTable.Rows(0)
                Return oRow
            End If
        Catch ex As DbException
            Throw New Exception("DB Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteRow", exx)
        Finally
            Con.Close()
            oDataTable = Nothing
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Excute Adapter
    ''' </summary>
    ''' <param name="oTable"></param>
    ''' <param name="cmdText"></param>
    ''' <param name="lngMaxID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExcuteAdapter(ByVal oTable As DataTable, ByVal cmdText As String, Optional ByRef lngMaxID As Long = 0) As Boolean

        Dim oProviderFactory As DbProviderFactory = DbProviderFactories.GetFactory(GetFactoryByProvider(_factory))
        Dim conn As DbConnection = oProviderFactory.CreateConnection
        conn.ConnectionString = ConnectionString
        Dim oSqlCmd As DbCommand = conn.CreateCommand
        Dim oDataAdapter As DbDataAdapter = oProviderFactory.CreateDataAdapter
        Dim oCmdBuilder As DbCommandBuilder = oProviderFactory.CreateCommandBuilder
        Dim trans As DbTransaction = Nothing
        Try

            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If

            trans = conn.BeginTransaction
            oSqlCmd.Transaction = trans

            oSqlCmd.Connection = conn
            oSqlCmd.CommandText = cmdText
            oSqlCmd.CommandType = CommandType.Text

            oDataAdapter.SelectCommand = oSqlCmd
            oCmdBuilder.DataAdapter = oDataAdapter
            oCmdBuilder.GetUpdateCommand()
            oCmdBuilder.GetInsertCommand()
            oCmdBuilder.GetDeleteCommand()
            oDataAdapter.Update(oTable)
            oDataAdapter.SelectCommand.CommandText = "SELECT @@IDENTITY"
            trans.Commit()

            '  lngMaxID = CType(oDataAdapter.SelectCommand.ExecuteScalar(), Long)

        Catch ex As DbException
            trans.Rollback()
            Throw New Exception("DB Exception ", ex)

        Catch exx As Exception
            trans.Rollback()
            Throw New Exception("ExeculateAdapter", exx)

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            oSqlCmd = Nothing
            oDataAdapter = Nothing
            oCmdBuilder = Nothing
        End Try

    End Function

    ''' <summary>
    ''' Prepare Command
    ''' </summary>
    ''' <param name="cmd">Assigns a <paramref name="connection"/> to the <paramref name="command"/> and discovers parameters if needed.</param>
    ''' <param name="conn">The connection to assign to the command.</param>
    ''' <param name="cmdType">The command that contains the query to prepare.</param>
    ''' <param name="cmdText"></param>
    ''' <param name="cmdParms"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PrepareCommand(ByRef cmd As DbCommand, ByRef conn As DbConnection, ByRef cmdType As CommandType, ByRef cmdText As String, ByRef cmdParms As DbParameter()) As Boolean
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            cmd.Connection = conn
            cmd.CommandText = cmdText
            cmd.Parameters.Clear()
            cmd.CommandType = cmdType

            If Not (IsNothing(cmdParms)) Then
                Dim param As DbParameter

                For Each param In cmdParms
                    cmd.Parameters.Add(param)
                Next
            End If
        Catch ex As DbException
            Throw New Exception("DB Exception ", ex)
        Catch exx As Exception
            Throw New Exception("PrepareCommand : ", exx)
        End Try
    End Function

End Class

Public Enum Providers As Integer
    Odbc = 1
    OleDb = 2
    SqlClient = 3
    OracleClient = 4
    MySql = 5
End Enum