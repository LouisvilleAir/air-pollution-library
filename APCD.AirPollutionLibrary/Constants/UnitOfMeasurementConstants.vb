'***********************************************************************************************************************
'Assembly Name: APCD.AirPollutionLibrary
'Filename: UnitOfMeasurementConstants.vb
'Author: Mike Farris
'Date: 10/04/2011
'Description: Constants class for the UnitOfMeasurement table of the AirPollution database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.AirPollution.Constants

    <Serializable()> Public Class UnitOfMeasurementConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const UnitOfMeasurementID As String = "UnitOfMeasurementID" 'primary key
            Public Const UnitOfMeasurementName As String = "UnitOfMeasurementName"
            Public Const PhysicalQuantityID As String = "PhysicalQuantityID"
            Public Const UnitSymbol As String = "UnitSymbol"
            Public Const UnitAQSCode As String = "UnitAQSCode"
            Public Const UnitEISCode As String = "UnitEISCode"
            Public Const UnitOfMeasurementComment As String = "UnitOfMeasurementComment"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
