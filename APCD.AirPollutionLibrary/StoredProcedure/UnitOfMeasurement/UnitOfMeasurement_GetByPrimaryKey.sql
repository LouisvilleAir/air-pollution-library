USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UnitOfMeasurement_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UnitOfMeasurement_GetByPrimaryKey]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: UnitOfMeasurement_GetByPrimaryKey
Author: Mike Farris
Date: 10/04/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.UnitOfMeasurement_GetByPrimaryKey(
    @UnitOfMeasurementID    int
)

AS

BEGIN

    SELECT 
        UnitOfMeasurementID,
        UnitOfMeasurementName,
        PhysicalQuantityID,
        UnitSymbol,
        UnitAQSCode,
        UnitEISCode,
        UnitOfMeasurementComment
    FROM UnitOfMeasurement
    WHERE
        UnitOfMeasurementID = @UnitOfMeasurementID

END

RETURN

GO

