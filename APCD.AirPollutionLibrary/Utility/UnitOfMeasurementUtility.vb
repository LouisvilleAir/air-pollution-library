'***********************************************************************************************************************
'Assembly Name: APCD.AirPollutionLibrary
'Filename: UnitOfMeasurementUtility.vb
'Author: Mike Farris
'Date: 10/04/2011
'Description: Utility class for the UnitOfMeasurement table of the AirPollution database.
'             Provides shared methods for accesssing the database as well as other utility functions.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.AirPollution.Business
Imports APCD.AirPollution.Collections
Imports APCD.AirPollution.Data

Namespace APCD.AirPollution.Utility

    <Serializable()> Public Class UnitOfMeasurementUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        ''Public Shared Function GetAll() As DataTable

        ''    Dim objUnitOfMeasurementDB As UnitOfMeasurementDB
        ''    objUnitOfMeasurementDB = New UnitOfMeasurementDB
        ''    Return objUnitOfMeasurementDB.GetAll

        ''End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objUnitOfMeasurementDB As UnitOfMeasurementDB
            objUnitOfMeasurementDB = New UnitOfMeasurementDB
            Return objUnitOfMeasurementDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strUnitOfMeasurementName As String) As UnitOfMeasurement

            Dim objUnitOfMeasurementDB As UnitOfMeasurementDB
            objUnitOfMeasurementDB = New UnitOfMeasurementDB
            Return objUnitOfMeasurementDB.GetByLookupName(strUnitOfMeasurementName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intUnitOfMeasurementID As Int32) As UnitOfMeasurement

            Dim objUnitOfMeasurementDB As UnitOfMeasurementDB
            objUnitOfMeasurementDB = New UnitOfMeasurementDB
            Return objUnitOfMeasurementDB.GetByPrimaryKey(intUnitOfMeasurementID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
