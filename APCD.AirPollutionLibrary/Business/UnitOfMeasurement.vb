'***********************************************************************************************************************
'Assembly Name: APCD.AirPollutionLibrary
'Filename: UnitOfMeasurement.vb
'Author: Mike Farris
'Date: 10/04/2011
'Description: Business class for the UnitOfMeasurement table of the AirPollution database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.AirPollution.Data

Namespace APCD.AirPollution.Business

    <Serializable()> Public Class UnitOfMeasurement

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intUnitOfMeasurementID As Int32 'primary key
        Private m_strUnitOfMeasurementName As String
        Private m_intPhysicalQuantityID As Int32
        Private m_strUnitSymbol As String
        Private m_strUnitAQSCode As String
        Private m_strUnitEISCode As String
        Private m_strUnitOfMeasurementComment As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property UnitOfMeasurementID() As Int32
            Get
                Return Me.m_intUnitOfMeasurementID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intUnitOfMeasurementID = Value
            End Set
        End Property

        Public Property UnitOfMeasurementName() As String
            Get
                Return Me.m_strUnitOfMeasurementName
            End Get
            Set(ByVal Value As String)
                Me.m_strUnitOfMeasurementName = Value
            End Set
        End Property

        Public Property PhysicalQuantityID() As Int32
            Get
                Return Me.m_intPhysicalQuantityID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPhysicalQuantityID = Value
            End Set
        End Property

        Public Property UnitSymbol() As String
            Get
                Return Me.m_strUnitSymbol
            End Get
            Set(ByVal Value As String)
                Me.m_strUnitSymbol = Value
            End Set
        End Property

        Public Property UnitAQSCode() As String
            Get
                Return Me.m_strUnitAQSCode
            End Get
            Set(ByVal Value As String)
                Me.m_strUnitAQSCode = Value
            End Set
        End Property

        Public Property UnitEISCode() As String
            Get
                Return Me.m_strUnitEISCode
            End Get
            Set(ByVal Value As String)
                Me.m_strUnitEISCode = Value
            End Set
        End Property

        Public Property UnitOfMeasurementComment() As String
            Get
                Return Me.m_strUnitOfMeasurementComment
            End Get
            Set(ByVal Value As String)
                Me.m_strUnitOfMeasurementComment = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert() As Int32

            Dim intReutrnValue As Int32
            Dim objUnitOfMeasurementDB As UnitOfMeasurementDB

            Try
                objUnitOfMeasurementDB = New UnitOfMeasurementDB
                intReutrnValue = objUnitOfMeasurementDB.Insert(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update() As Int32

            Dim intReutrnValue As Int32
            Dim objUnitOfMeasurementDB As UnitOfMeasurementDB

            Try
                objUnitOfMeasurementDB = New UnitOfMeasurementDB
                intReutrnValue = objUnitOfMeasurementDB.Update(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete() As Int32

            Dim intReutrnValue As Int32
            Dim objUnitOfMeasurementDB As UnitOfMeasurementDB

            Try
                objUnitOfMeasurementDB = New UnitOfMeasurementDB
                intReutrnValue = objUnitOfMeasurementDB.Delete(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

#End Region '----- DML -----

#Region "----- Object Class Overloads-----"

        Public Overrides Function ToString() As String

            Dim strbToString As Text.StringBuilder

            strbToString = New Text.StringBuilder
            With strbToString

                .Append(Constants.UnitOfMeasurementConstants.FieldName.UnitOfMeasurementID)
                .Append(":")
                .Append(Me.UnitOfMeasurementID)
                .Append(ControlChars.CrLf)

                .Append(Constants.UnitOfMeasurementConstants.FieldName.UnitOfMeasurementName)
                .Append(":")
                .Append(Me.UnitOfMeasurementName)
                .Append(ControlChars.CrLf)

                .Append(Constants.UnitOfMeasurementConstants.FieldName.PhysicalQuantityID)
                .Append(":")
                .Append(Me.PhysicalQuantityID)
                .Append(ControlChars.CrLf)

                .Append(Constants.UnitOfMeasurementConstants.FieldName.UnitSymbol)
                .Append(":")
                .Append(Me.UnitSymbol)
                .Append(ControlChars.CrLf)

                .Append(Constants.UnitOfMeasurementConstants.FieldName.UnitAQSCode)
                .Append(":")
                .Append(Me.UnitAQSCode)
                .Append(ControlChars.CrLf)

                .Append(Constants.UnitOfMeasurementConstants.FieldName.UnitEISCode)
                .Append(":")
                .Append(Me.UnitEISCode)
                .Append(ControlChars.CrLf)

                .Append(Constants.UnitOfMeasurementConstants.FieldName.UnitOfMeasurementComment)
                .Append(":")
                .Append(Me.UnitOfMeasurementComment)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.UnitOfMeasurementID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objUnitOfMeasurement As UnitOfMeasurement) As Boolean

            Dim blnEquals As Boolean

            If ((Me.UnitOfMeasurementID = objUnitOfMeasurement.UnitOfMeasurementID) _
                AndAlso (Me.UnitOfMeasurementName = objUnitOfMeasurement.UnitOfMeasurementName) _
                AndAlso (Me.PhysicalQuantityID = objUnitOfMeasurement.PhysicalQuantityID) _
                AndAlso (Me.UnitSymbol = objUnitOfMeasurement.UnitSymbol) _
                AndAlso (Me.UnitAQSCode = objUnitOfMeasurement.UnitAQSCode) _
                AndAlso (Me.UnitEISCode = objUnitOfMeasurement.UnitEISCode) _
                AndAlso (Me.UnitOfMeasurementComment = objUnitOfMeasurement.UnitOfMeasurementComment)) Then
                blnEquals = True
            Else
                blnEquals = False
            End If

            Return blnEquals

        End Function

#End Region '----- Object Class Overloads-----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
