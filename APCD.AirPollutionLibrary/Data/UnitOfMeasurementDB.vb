'***********************************************************************************************************************
'Assembly Name: APCD.AirPollutionLibrary
'Filename: UnitOfMeasurementDB.vb
'Author: Mike Farris
'Date: 10/04/2011
'Description: Data access class for the UnitOfMeasurement table of the AirPollution database.
'             Provides Insert, Update, Delete, and Select operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports System.Data.OleDb
Imports Tools.Data
Imports APCD.AirPollution.Business
Imports APCD.AirPollution.Collections
Imports APCD.AirPollution.Constants
Imports APCD.AirPollution.Globals

Namespace APCD.AirPollution.Data

    <Serializable()> Friend Class UnitOfMeasurementDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared UnitOfMeasurementID As Int32 'primary key
            Public Shared UnitOfMeasurementName As Int32
            Public Shared PhysicalQuantityID As Int32
            Public Shared UnitSymbol As Int32
            Public Shared UnitAQSCode As Int32
            Public Shared UnitEISCode As Int32
            Public Shared UnitOfMeasurementComment As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "UnitOfMeasurement_Insert"
            Public Const Update As String = "UnitOfMeasurement_Update"
            Public Const Delete As String = "UnitOfMeasurement_Delete"
            Public Const GetByPrimaryKey As String = "UnitOfMeasurement_GetByPrimaryKey"
            Public Const GetAll As String = "UnitOfMeasurement_GetAll"
            Public Const GetLookupTable As String = "UnitOfMeasurement_GetLookupTable"
            Public Const GetByLookupName As String = "UnitOfMeasurement_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintUnitOfMeasurementID As OleDbParameter 'primary key
        Private m_prmstrUnitOfMeasurementName As OleDbParameter
        Private m_prmintPhysicalQuantityID As OleDbParameter
        Private m_prmstrUnitSymbol As OleDbParameter
        Private m_prmstrUnitAQSCode As OleDbParameter
        Private m_prmstrUnitEISCode As OleDbParameter
        Private m_prmstrUnitOfMeasurementComment As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const UnitOfMeasurementID As String = "@UnitOfMeasurementID"
            Public Const UnitOfMeasurementName As String = "@UnitOfMeasurementName"
            Public Const PhysicalQuantityID As String = "@PhysicalQuantityID"
            Public Const UnitSymbol As String = "@UnitSymbol"
            Public Const UnitAQSCode As String = "@UnitAQSCode"
            Public Const UnitEISCode As String = "@UnitEISCode"
            Public Const UnitOfMeasurementComment As String = "@UnitOfMeasurementComment"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objUnitOfMeasurement As UnitOfMeasurement) As Int32

            Return Me.DMLHelper(objUnitOfMeasurement, DMLType.Insert)

        End Function

        Friend Function Update(ByVal objUnitOfMeasurement As UnitOfMeasurement) As Int32

            Return Me.DMLHelper(objUnitOfMeasurement, DMLType.Update)

        End Function

        Friend Function Delete(ByVal objUnitOfMeasurement As UnitOfMeasurement) As Int32

            Return Me.DMLHelper(objUnitOfMeasurement, DMLType.Delete)

        End Function

        Private Function DMLHelper(ByVal objUnitOfMeasurement As UnitOfMeasurement, ByVal iDMLType As DMLType) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objUnitOfMeasurement, iDMLType)
                commandParameters = .GetParameterArray(iDMLType)
                Select Case iDMLType
                    Case DMLType.Insert
                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Insert, commandParameters)
                    Case DMLType.Update
                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Update, commandParameters)
                    Case DMLType.Delete
                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Delete, commandParameters)
                End Select
            End With

            Return intReturnValue

        End Function

#End Region '----- DML -----

#Region "----- Helper Methods -----"

        Private Sub InitializeParameterObjects()

            Me.m_prmintUnitOfMeasurementID = Nothing
            Me.m_prmintUnitOfMeasurementID = New OleDbParameter

            Me.m_prmstrUnitOfMeasurementName = Nothing
            Me.m_prmstrUnitOfMeasurementName = New OleDbParameter

            Me.m_prmintPhysicalQuantityID = Nothing
            Me.m_prmintPhysicalQuantityID = New OleDbParameter

            Me.m_prmstrUnitSymbol = Nothing
            Me.m_prmstrUnitSymbol = New OleDbParameter

            Me.m_prmstrUnitAQSCode = Nothing
            Me.m_prmstrUnitAQSCode = New OleDbParameter

            Me.m_prmstrUnitEISCode = Nothing
            Me.m_prmstrUnitEISCode = New OleDbParameter

            Me.m_prmstrUnitOfMeasurementComment = Nothing
            Me.m_prmstrUnitOfMeasurementComment = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objUnitOfMeasurement As UnitOfMeasurement, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintUnitOfMeasurementID
                            .ParameterName = ParameterName.UnitOfMeasurementID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objUnitOfMeasurement.UnitOfMeasurementID
                        End With

                        With .m_prmstrUnitOfMeasurementName
                            .ParameterName = ParameterName.UnitOfMeasurementName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitOfMeasurementName
                        End With

                        With .m_prmintPhysicalQuantityID
                            .ParameterName = ParameterName.PhysicalQuantityID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer

                            .Value = objUnitOfMeasurement.PhysicalQuantityID
                        End With

                        With .m_prmstrUnitSymbol
                            .ParameterName = ParameterName.UnitSymbol
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitSymbol
                        End With

                        With .m_prmstrUnitAQSCode
                            .ParameterName = ParameterName.UnitAQSCode
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitAQSCode
                        End With

                        With .m_prmstrUnitEISCode
                            .ParameterName = ParameterName.UnitEISCode
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitEISCode
                        End With

                        With .m_prmstrUnitOfMeasurementComment
                            .ParameterName = ParameterName.UnitOfMeasurementComment
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitOfMeasurementComment
                        End With

                    Case DMLType.Update

                        With .m_prmintUnitOfMeasurementID
                            .ParameterName = "@UnitOfMeasurementID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objUnitOfMeasurement.UnitOfMeasurementID
                        End With

                        With .m_prmstrUnitOfMeasurementName
                            .ParameterName = "@UnitOfMeasurementName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitOfMeasurementName
                        End With

                        With .m_prmintPhysicalQuantityID
                            .ParameterName = "@PhysicalQuantityID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objUnitOfMeasurement.PhysicalQuantityID
                        End With

                        With .m_prmstrUnitSymbol
                            .ParameterName = "@UnitSymbol"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitSymbol
                        End With

                        With .m_prmstrUnitAQSCode
                            .ParameterName = "@UnitAQSCode"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitAQSCode
                        End With

                        With .m_prmstrUnitEISCode
                            .ParameterName = "@UnitEISCode"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitEISCode
                        End With

                        With .m_prmstrUnitOfMeasurementComment
                            .ParameterName = "@UnitOfMeasurementComment"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarWChar
                            .Value = objUnitOfMeasurement.UnitOfMeasurementComment
                        End With

                    Case DMLType.Delete

                        With .m_prmintUnitOfMeasurementID
                            .ParameterName = "@UnitOfMeasurementID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objUnitOfMeasurement.UnitOfMeasurementID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(6) {}
                    commandParameters(0) = Me.m_prmintUnitOfMeasurementID
                    commandParameters(1) = Me.m_prmstrUnitOfMeasurementName
                    commandParameters(2) = Me.m_prmintPhysicalQuantityID
                    commandParameters(3) = Me.m_prmstrUnitSymbol
                    commandParameters(4) = Me.m_prmstrUnitAQSCode
                    commandParameters(5) = Me.m_prmstrUnitEISCode
                    commandParameters(6) = Me.m_prmstrUnitOfMeasurementComment
                Case DMLType.Update
                    commandParameters = New OleDbParameter(6) {}
                    commandParameters(0) = Me.m_prmintUnitOfMeasurementID
                    commandParameters(1) = Me.m_prmstrUnitOfMeasurementName
                    commandParameters(2) = Me.m_prmintPhysicalQuantityID
                    commandParameters(3) = Me.m_prmstrUnitSymbol
                    commandParameters(4) = Me.m_prmstrUnitAQSCode
                    commandParameters(5) = Me.m_prmstrUnitEISCode
                    commandParameters(6) = Me.m_prmstrUnitOfMeasurementComment
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintUnitOfMeasurementID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.UnitOfMeasurementID = dr.GetOrdinal(UnitOfMeasurementConstants.FieldName.UnitOfMeasurementID)
            FieldOrdinal.UnitOfMeasurementName = dr.GetOrdinal(UnitOfMeasurementConstants.FieldName.UnitOfMeasurementName)
            FieldOrdinal.PhysicalQuantityID = dr.GetOrdinal(UnitOfMeasurementConstants.FieldName.PhysicalQuantityID)
            FieldOrdinal.UnitSymbol = dr.GetOrdinal(UnitOfMeasurementConstants.FieldName.UnitSymbol)
            FieldOrdinal.UnitAQSCode = dr.GetOrdinal(UnitOfMeasurementConstants.FieldName.UnitAQSCode)
            FieldOrdinal.UnitEISCode = dr.GetOrdinal(UnitOfMeasurementConstants.FieldName.UnitEISCode)
            FieldOrdinal.UnitOfMeasurementComment = dr.GetOrdinal(UnitOfMeasurementConstants.FieldName.UnitOfMeasurementComment)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        ''Friend Function GetAll() As DataTable

        ''    Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        ''End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strUnitOfMeasurementName As String) As UnitOfMeasurement

            Dim objUnitOfMeasurement As UnitOfMeasurement
            Dim cnAirPollution As OleDbConnection
            Dim drUnitOfMeasurement As OleDbDataReader
            Dim commandParameters() As OleDbParameter
            Dim prmstrUnitOfMeasurementName As OleDbParameter = New OleDbParameter

            With prmstrUnitOfMeasurementName
                .ParameterName = ParameterName.UnitOfMeasurementName
                .Direction = ParameterDirection.Input
                .Value = strUnitOfMeasurementName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrUnitOfMeasurementName

            cnAirPollution = New OleDbConnection(GlobalVariables.ConnectionString)
            cnAirPollution.Open()
            drUnitOfMeasurement = OleDbHelper.ExecuteReader(cnAirPollution, StoredProcedure.GetByLookupName, commandParameters)
            If (drUnitOfMeasurement.HasRows) Then
                objUnitOfMeasurement = New UnitOfMeasurement
                Call SetFieldOrdinalValues(drUnitOfMeasurement)
                drUnitOfMeasurement.Read()
                With objUnitOfMeasurement
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementID))) Then
                        .UnitOfMeasurementID = CInt(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementID))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementName))) Then
                        .UnitOfMeasurementName = CStr(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementName))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.PhysicalQuantityID))) Then
                        .PhysicalQuantityID = CInt(drUnitOfMeasurement(FieldOrdinal.PhysicalQuantityID))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitSymbol))) Then
                        .UnitSymbol = CStr(drUnitOfMeasurement(FieldOrdinal.UnitSymbol))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitAQSCode))) Then
                        .UnitAQSCode = CStr(drUnitOfMeasurement(FieldOrdinal.UnitAQSCode))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitEISCode))) Then
                        .UnitEISCode = CStr(drUnitOfMeasurement(FieldOrdinal.UnitEISCode))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementComment))) Then
                        .UnitOfMeasurementComment = CStr(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementComment))
                    End If
                End With
            End If
            drUnitOfMeasurement.Close()
            cnAirPollution.Close()

            Return objUnitOfMeasurement

        End Function

        Friend Function GetByPrimaryKey(ByVal intUnitOfMeasurementID As Int32) As UnitOfMeasurement

            Dim objUnitOfMeasurement As UnitOfMeasurement
            Dim cnAirPollution As OleDbConnection
            Dim drUnitOfMeasurement As OleDbDataReader
            Dim commandParameters() As OleDbParameter
            Dim prmintUnitOfMeasurementID As OleDbParameter = New OleDbParameter

            With prmintUnitOfMeasurementID
                .ParameterName = ParameterName.UnitOfMeasurementID
                .Direction = ParameterDirection.Input
                .Value = intUnitOfMeasurementID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintUnitOfMeasurementID

            cnAirPollution = New OleDbConnection(GlobalVariables.ConnectionString)
            cnAirPollution.Open()
            drUnitOfMeasurement = OleDbHelper.ExecuteReader(cnAirPollution, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drUnitOfMeasurement.HasRows) Then
                objUnitOfMeasurement = New UnitOfMeasurement
                Call SetFieldOrdinalValues(drUnitOfMeasurement)
                drUnitOfMeasurement.Read()
                With objUnitOfMeasurement
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementID))) Then
                        .UnitOfMeasurementID = CInt(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementID))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementName))) Then
                        .UnitOfMeasurementName = CStr(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementName))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.PhysicalQuantityID))) Then
                        .PhysicalQuantityID = CInt(drUnitOfMeasurement(FieldOrdinal.PhysicalQuantityID))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitSymbol))) Then
                        .UnitSymbol = CStr(drUnitOfMeasurement(FieldOrdinal.UnitSymbol))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitAQSCode))) Then
                        .UnitAQSCode = CStr(drUnitOfMeasurement(FieldOrdinal.UnitAQSCode))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitEISCode))) Then
                        .UnitEISCode = CStr(drUnitOfMeasurement(FieldOrdinal.UnitEISCode))
                    End If
                    If (Not IsDBNull(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementComment))) Then
                        .UnitOfMeasurementComment = CStr(drUnitOfMeasurement(FieldOrdinal.UnitOfMeasurementComment))
                    End If
                End With
            End If
            drUnitOfMeasurement.Close()
            cnAirPollution.Close()

            Return objUnitOfMeasurement

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
