CREATE TABLE [dbo].[WBPerioden] (
    [Id]     INT            NOT NULL,
    [Key]    NVARCHAR (50)  NULL,
    [Title]  NVARCHAR (50)  NULL,
    [Status] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[WBKenmerken] (
    [Id]          INT            NOT NULL,
    [Key]         NVARCHAR (50)  NULL,
    [Title]       NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[WBDataSet] (
    [Id]                                INT          NOT NULL,
    [Kenmerken]                         VARCHAR (50) NOT NULL,
    [Perioden]                          VARCHAR (50) NOT NULL,
    [WerkzameBeroepsbevolkingTotaal]    INT          NULL,
    [TotaalCreatieveBeroepen]           INT          NULL,
    [Kunsten]                           INT          NULL,
    [MediaEnEntertainment]              INT          NULL,
    [CreatieveZakelijkeDienstverlening] INT          NULL,
    [OverigeCreatieveBeroepen]          INT          NULL,
    [WerkzPersMetNietCreatieveBeroep]   INT          NULL,
    [WerkzPersMetBeroepOnbekend]        INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[DSPersoonsKenmerken] (
    [Id]          INT            NOT NULL,
    [Key]         NVARCHAR (50)  NULL,
    [Title]       NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[DSMboRichtingEnSector] (
    [Id]          INT            NOT NULL,
    [Key]         NVARCHAR (50)  NULL,
    [Title]       NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[DSMboLeerwegEnNiveau] (
    [Id]          INT            NOT NULL,
    [Key]         NVARCHAR (50)  NULL,
    [Title]       NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[DSDataSet] (
    [Id]                             INT           NOT NULL,
    [Geslacht]                       NVARCHAR (50) NULL,
    [MboLeerwegEnNiveau]             NVARCHAR (50) NULL,
    [MboRichtingEnSector]            NVARCHAR (50) NULL,
    [Persoonskenmerken]              NVARCHAR (50) NULL,
    [Perioden]                       NVARCHAR (50) NULL,
    [TotaalDoorstroomLeerling_1]     INT           NULL,
    [Leerjaar12_2]                   INT           NULL,
    [Vmbo3Totaal_3]                  INT           NULL,
    [Totaal_4]                       INT           NULL,
    [LandbouwBKG_5]                  INT           NULL,
    [ZorgEnWelzijnBKG_6]             INT           NULL,
    [EconomieBKG_7]                  INT           NULL,
    [TechniekBKG_8]                  INT           NULL,
    [CombinatieBKG_9]                INT           NULL,
    [GeenSectorT_10]                 INT           NULL,
    [Totaal_11]                      INT           NULL,
    [LandbouwBKG_12]                 INT           NULL,
    [ZorgEnWelzijnBKG_13]            INT           NULL,
    [EconomieBKG_14]                 INT           NULL,
    [TechniekBKG_15]                 INT           NULL,
    [CombinatieBKG_16]               INT           NULL,
    [GeenSectorT_17]                 INT           NULL,
    [Totaal_18]                      INT           NULL,
    [LandbouwBKG_19]                 INT           NULL,
    [ZorgEnWelzijnBKG_20]            INT           NULL,
    [EconomieBKG_21]                 INT           NULL,
    [TechniekBKG_22]                 INT           NULL,
    [CombinatieBKG_23]               INT           NULL,
    [GeenSectorT_24]                 INT           NULL,
    [Totaal_25]                      INT           NULL,
    [Totaal_26]                      INT           NULL,
    [BasisberoepsgerichteLeerweg_27] INT           NULL,
    [KaderberoepsgerichteLeerweg_28] INT           NULL,
    [Totaal_29]                      INT           NULL,
    [GemengdeLeerweg_30]             INT           NULL,
    [TheoretischeLeerweg_31]         INT           NULL,
    [Totaal_32]                      INT           NULL,
    [Totaal_33]                      INT           NULL,
    [BasisberoepsgerichteLeerweg_34] INT           NULL,
    [KaderberoepsgerichteLeerweg_35] INT           NULL,
    [Totaal_36]                      INT           NULL,
    [GemengdeLeerweg_37]             INT           NULL,
    [TheoretischeLeerweg_38]         INT           NULL,
    [Totaal_39]                      INT           NULL,
    [Landbouw_40]                    INT           NULL,
    [ZorgEnWelzijn_40]               INT           NULL,
    [Economie_42]                    INT           NULL,
    [Techniek_43]                    INT           NULL,
    [Combinatie_44]                  INT           NULL,
    [Totaal_45]                      INT           NULL,
    [Landbouw_46]                    INT           NULL,
    [ZorgEnWelzijn_47]               INT           NULL,
    [Economie_48]                    INT           NULL,
    [Techniek_49]                    INT           NULL,
    [Combinatie_50]                  INT           NULL,
    [Totaal_51]                      INT           NULL,
    [Landbouw_52]                    INT           NULL,
    [ZorgEnWelzijn_53]               INT           NULL,
    [Economie_54]                    INT           NULL,
    [Techniek_55]                    INT           NULL,
    [Combinatie_56]                  INT           NULL,
    [Totaal_57]                      INT           NULL,
    [Totaal_58]                      INT           NULL,
    [Landbouw_59]                    INT           NULL,
    [ZorgEnWelzijn_60]               INT           NULL,
    [Economie_61]                    INT           NULL,
    [Techniek_62]                    INT           NULL,
    [Combinatie_63]                  INT           NULL,
    [TheoretischeLeerweg_64]         INT           NULL,
    [HavoVwoInclAlgLeerjr_65]        INT           NULL,
    [Havo4Totaal_66]                 INT           NULL,
    [Havo5Totaal_67]                 INT           NULL,
    [Havo5MetDiploma_68]             INT           NULL,
    [Havo5ZonderDiploma_69]          INT           NULL,
    [Vwo46Totaal_70]                 INT           NULL,
    [Vwo6MetDiploma_71]              INT           NULL,
    [Vwo46ZonderDiploma_72]          INT           NULL,
    [Praktijkonderwijs_73]           INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ADPerioden] (
    [Id]     INT            NOT NULL,
    [Key]    NVARCHAR (50)  NULL,
    [Title]  NVARCHAR (50)  NULL,
    [Status] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ADHerkomst] (
    [Id]              INT           NOT NULL,
    [Key]             NVARCHAR (50) NULL,
    [Title]           NVARCHAR (50) NULL,
    [CategoryGroupID] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ADGeslacht] (
    [Id]    INT           NOT NULL,
    [Key]   NVARCHAR (50) NULL,
    [Title] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ADDataSet] (
    [Id]                    INT           NOT NULL,
    [Geslacht]              NVARCHAR (30) NOT NULL,
    [Herkomst]              NVARCHAR (30) NOT NULL,
    [Perioden]              NVARCHAR (30) NOT NULL,
    [Alcoholgebruik]        FLOAT (53)    NULL,
    [BingeDrinken]          FLOAT (53)    NULL,
    [CannabisOoitGebruikt]  FLOAT (53)    NULL,
    [CannabisActiefGebruik] FLOAT (53)    NULL,
    [TotaalGebruik]         FLOAT (53)    NULL,
    [XTC]                   FLOAT (53)    NULL,
    [Cocaine]               FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

