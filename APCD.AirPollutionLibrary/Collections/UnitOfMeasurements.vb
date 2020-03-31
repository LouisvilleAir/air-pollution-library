'***********************************************************************************************************************
'Assembly Name: APCD.AirPollutionLibrary
'Filename: UnitOfMeasurements.vb
'Author: Mike Farris
'Date: 10/04/2011
'Description: Custom collection class for the UnitOfMeasurement business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.AirPollution.Business

Namespace APCD.AirPollution.Collections

    <Serializable()> Public Class UnitOfMeasurements
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblUnitOfMeasurement As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objUnitOfMeasurement As UnitOfMeasurement)

            Dim intHashCode As Int32

            Try
                intHashCode = objUnitOfMeasurement.GetHashCode()
                Me.m_htblUnitOfMeasurement.Add(intHashCode, objUnitOfMeasurement)
                Me.InnerList.Add(objUnitOfMeasurement)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objUnitOfMeasurement As UnitOfMeasurement)

            Dim intHashCode As Int32

            intHashCode = objUnitOfMeasurement.GetHashCode()
            If (Me.m_htblUnitOfMeasurement.Contains(intHashCode)) Then
                Me.m_htblUnitOfMeasurement.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As UnitOfMeasurement

            Get
                Return CType(Me.InnerList(intIndex), UnitOfMeasurement)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As UnitOfMeasurement

            Get
                Return CType(Me.m_htblUnitOfMeasurement.Item(hashCode), UnitOfMeasurement)
            End Get

        End Property

        Public Function Contains(ByVal objUnitOfMeasurement As UnitOfMeasurement) As Boolean

            Dim intHashCode As Int32

            intHashCode = objUnitOfMeasurement.GetHashCode()
            Return Me.m_htblUnitOfMeasurement.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
