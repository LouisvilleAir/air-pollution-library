USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UnitOfMeasurement_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UnitOfMeasurement_Insert]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: UnitOfMeasurement_Insert
Author: Mike Farris
Date: 10/04/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.UnitOfMeasurement_Insert(
    @UnitOfMeasurementID    int,
    @UnitOfMeasurementName    nvarchar(100),
    @PhysicalQuantityID    int = null,
    @UnitSymbol    nvarchar(30) = null,
    @UnitAQSCode    nvarchar(6) = null,
    @UnitEISCode    nvarchar(20) = null,
    @UnitOfMeasurementComment    nvarchar(510) = null
)

AS

BEGIN

    INSERT INTO UnitOfMeasurement
    (
        UnitOfMeasurementID,
        UnitOfMeasurementName,
        PhysicalQuantityID,
        UnitSymbol,
        UnitAQSCode,
        UnitEISCode,
        UnitOfMeasurementComment
    )
    VALUES
    (
        @UnitOfMeasurementID,
        @UnitOfMeasurementName,
        @PhysicalQuantityID,
        @UnitSymbol,
        @UnitAQSCode,
        @UnitEISCode,
        @UnitOfMeasurementComment
    )


END

RETURN

GO

