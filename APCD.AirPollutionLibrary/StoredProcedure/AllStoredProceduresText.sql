USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Insert]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: sysdiagrams_Insert
Author: Mike Farris
Date: 10/04/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Insert(
    @name    nvarchar(256),
    @principal_id    int,
    @diagram_id    int OUTPUT,
    @version    int = null,
    @definition    varbinary = null
)

AS

BEGIN

    INSERT INTOsysdiagrams
    (
        name,
        principal_id,
        version,
        definition
    )
    VALUES
    (
        @name,
        @principal_id,
        @version,
        @definition
    )


END

RETURN

GO

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Update]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: sysdiagrams_Update
Author: Mike Farris
Date: 10/04/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Update(
    @name    nvarchar(256),
    @principal_id    int,
    @diagram_id    int,
    @version    int = null,
    @definition    varbinary = null
)

AS

BEGIN

    UPDATE sysdiagrams
    SET 
        principal_id = @principal_id,
        diagram_id = @diagram_id,
        version = @version,
        definition = @definition
    WHERE
        name = @name


END

RETURN

GO

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Delete]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: sysdiagrams_Delete
Author: Mike Farris
Date: 10/04/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Delete(
    @name    nvarchar(256)
)

AS

BEGIN

    DELETE FROMsysdiagrams
    WHERE
        name = @name

END

RETURN

GO

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByPrimaryKey]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: sysdiagrams_GetByPrimaryKey
Author: Mike Farris
Date: 10/04/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByPrimaryKey(
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        name = @name

END

RETURN

GO

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetAll]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: sysdiagrams_GetAll
Author: Mike Farris
Date: 10/04/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetAll
AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams

END

RETURN

GO

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByprincipal_id_name]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByprincipal_id_name]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: sysdiagrams_GetByprincipal_id_name
Author: Mike Farris
Date: 10/04/2011
Description:  Returns all of the records for the given (principal_id, name) passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByprincipal_id_name
(
    @principal_id    int,
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        principal_id = @principal_id
        AND name = @name
END

RETURN

GO

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByprincipal_id]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByprincipal_id]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: sysdiagrams_GetByprincipal_id
Author: Mike Farris
Date: 10/04/2011
Description:  Returns all of the records for the given principal_id passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByprincipal_id
(
    @principal_id    int
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        principal_id = @principal_id

END

RETURN

GO

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByname]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByname]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: sysdiagrams_GetByname
Author: Mike Farris
Date: 10/04/2011
Description:  Returns all of the records for the given name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByname
(
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        name = @name

END

RETURN

GO

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

    INSERT INTOUnitOfMeasurement
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

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UnitOfMeasurement_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UnitOfMeasurement_Delete]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: UnitOfMeasurement_Delete
Author: Mike Farris
Date: 10/04/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.UnitOfMeasurement_Delete(
    @UnitOfMeasurementID    int
)

AS

BEGIN

    DELETE FROMUnitOfMeasurement
    WHERE
        UnitOfMeasurementID = @UnitOfMeasurementID

END

RETURN

GO

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

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UnitOfMeasurement_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UnitOfMeasurement_GetAll]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: UnitOfMeasurement_GetAll
Author: Mike Farris
Date: 10/04/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.UnitOfMeasurement_GetAll
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

END

RETURN

GO

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

USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UnitOfMeasurement_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UnitOfMeasurement_GetByLookupName]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: UnitOfMeasurement_GetByLookupName
Author: Mike Farris
Date: 10/04/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.UnitOfMeasurement_GetByLookupName(
    @UnitOfMeasurementName    nvarchar(100)
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
        UnitOfMeasurementName = @UnitOfMeasurementName

END

RETURN

GO

