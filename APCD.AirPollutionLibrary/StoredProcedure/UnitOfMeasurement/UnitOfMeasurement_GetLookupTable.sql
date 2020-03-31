USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UnitOfMeasurement_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UnitOfMeasurement_GetLookupTable]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: UnitOfMeasurement_GetLookupTable
Author: Mike Farris
Date: 10/04/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.UnitOfMeasurement_GetLookupTable
AS

BEGIN

    SELECT 
        UnitOfMeasurementID,
        UnitOfMeasurementName
    FROM UnitOfMeasurement
    ORDER BY UnitOfMeasurementName

END

RETURN

GO

