USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UnitOfMeasurement_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UnitOfMeasurement_Update]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: UnitOfMeasurement_Update
Author: Mike Farris
Date: 10/04/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.UnitOfMeasurement_Update(
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

    UPDATE UnitOfMeasurement
    SET 
        UnitOfMeasurementName = @UnitOfMeasurementName,
        PhysicalQuantityID = @PhysicalQuantityID,
        UnitSymbol = @UnitSymbol,
        UnitAQSCode = @UnitAQSCode,
        UnitEISCode = @UnitEISCode,
        UnitOfMeasurementComment = @UnitOfMeasurementComment
    WHERE
        UnitOfMeasurementID = @UnitOfMeasurementID


END

RETURN

GO

