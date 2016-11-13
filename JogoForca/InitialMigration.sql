﻿CREATE TABLE [dbo].[Palavra] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](max),
    CONSTRAINT [PK_dbo.Palavra] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Usuario] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](max),
    [Pontuacao] [int] NOT NULL,
    [Dificuldade] [nvarchar](max),
    CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201611131712060_Inicial', N'JogoForca.Repositorio.Migrations.Configuration',  0x1F8B0800000000000400ED58CB6EE33614DD17E83F085CB54046CC63D306F20C523B2ED28E13234A664F4BD70E518A5445CAB0BFAD8B7E527F612EF57E588E931899022DBCB1C87BCF7DF2F04AFFFCF5B7F7691309670D89E64A8EC8997B4A1C90810AB95C8D486A961F7E229F3E7EFF9D771D461BE74B297761E55053EA11793226BEA454074F1031ED463C4894564BE3062AA22C54F4FCF4F4677A764601210862398E779F4AC323C81EF071AC6400B1499998A910842ED671C7CF509D5B16818E590023F29B5AA9A94A02E6DE43AC34372AE18A3857823374C607B1240E93521966D0D5CB470DBE49945CF9312E30F1B08D01E5964C682842B8ACC50F8DE6F4DC46436BC5122A48B551D10B01CF2E8AF4D0AEFAAB924CAAF46102AF31D1666BA3CE9238227326D83A619A385D6397639158C1668E272AE2922B37AF8B5B2A9F383D9193AA3BB089ECEFC419A7C2A4098C24A42661E2C499A70BC183DF61FBA0FE003992A9104D67D15DDC6B2DE0D23C513124667B0FCB22849B9038B4AD47BB8A955A43270FEE469A8B73E2DCA271B61050F54223113E3615FC0A121266209C336320911603B26CF6AC776CDDAA084A6BD87C78948833639BCF2057E66944F02F71A67C0361B95278F028399E3C5432490A6D231EAD0BB9B7BC8F3A65D9817845750BDDFF8BFBCEC5ED1B992B896C1830F55C5CFB61267CC98354842C7CDF7E443E378C63860B3FEC336C8C9AC004B96A17F5204D17FDA90B73EDC0725C1F4C8FC56A3F72F677EB2DBA1FA33A2A3D886A6757C85570F52D45F36BAABCCEE8C07DE6CD581C63F61BF75BB1E2F8F9E536FEE0BF9CF2A31C83067A07F357DE5696B0FDD90A3ABBB646214C79A2CD8419B660B6FEE330DA21D62EE5408A4B6B9D6A758F7F9DF952C1FECF95765EF4EE10549DCB298617E159CE2285CAA3612F32653FC0DD6407AF8C95482339C44DFBB473A668EAE72B7D048F767CEFE689F612D561C86EE20F2A4BD9E66FAFCA00D2014519D4FCD635194268507313A6B17C38568B9F9B68AD8D77EE971ECF75452AEB15DF7578CD2B38E6F961BE473AB9087130516B1E5AC2F1B7DA40E45A01D7FF538C05C7786B8119937C09DAE44307C161FABCF332F0EF19CCA9D6A138703A7FF7C989DBAC3E3B1BBD7000690E4B72CD92E089253F446CF36313E908D3EE7F3A5B078C8F99BB6F1F1E8F56C2FE80D81D3E8E30FEE55C3222E1C2E62177F498C3E12EFCB74E8E7DE6F468F363893701CD573584FD742221B094548396323772A9CAA262644D8F4A914ECD6760588825B84A0C5FB2C0E076005A676F0C5F984851E43A5A407823EF5213A7E64A6B8816A2F5D2E4D1FDF6B3F1B8EDB37717DB277D8C10D04D8E21C09DFC25E522ACFC9EF67B7E08C2766371ACD12B7C6342B8D5B642BA55F240A0227D1388415A527880281608A6EFA4CFD6F01ADFF045E933AC58B02D2FC06190E70BD14EBB37E16C95B0481718B5BEFD0048ED17C08F5F016A80327433140000 , N'6.1.3-40302')

EXECUTE sp_rename @objname = N'dbo.Palavras', @newname = N'Palavra', @objtype = N'OBJECT'
IF object_id('[PK_dbo.Palavras]') IS NOT NULL BEGIN
    EXECUTE sp_rename @objname = N'[PK_dbo.Palavras]', @newname = N'PK_dbo.Palavra', @objtype = N'OBJECT'
END
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201611131725049_AutomaticMigration', N'JogoForca.Repositorio.Migrations.Configuration',  0x1F8B0800000000000400ED58C96EE34610BD07C83F107D4A000FDBCB2531A8193892153819D98269CFBD4596E4467A61D84D43FAB61CF249F985A9E6BE48B2BCC01320812E6277D5ABB55F17F9CF5F7F079FD652788F901AAED5889CF8C7C40315E998ABD5886476F9E127F2E9E3F7DF0597B15C7B5F2AB93327879ACA8CC883B5C939A5267A00C98C2F79946AA397D68FB4A42CD6F4F4F8F8677A724201210862795E709B29CB25E40FF838D62A82C4664CCC740CC294EBB813E6A8DE3593601216C188FCA6577AAAD388F9B79068C3AD4EB926DE85E00C9D09412C89C794D2965974F5FCDE406853AD5661820B4CDC6D1240B9251306CA10CE1BF143A3393E75D1D046B1828A3263B57C26E0C959991EDA577F5192499D3E4CE02526DA6E5CD479124764CE047B4C19F1FAB6CEC7227572ED144FB4E48A6BBF288B5FEA1E790389A3BA37B085DCEFC81B67C266298C14643665E2C89B670BC1A3DF6173A7FF00355299106D57D159DCEB2CE0D23CD509A476730BCB3280AB9878B4AB47FB8AB55A4BA788ED4AD9B353E25DA371B6105077422B0F21B614FC0A0A5266219E336B21550E03F25C0EACF76C5D6B0995356C3D3C48C49BB1F567502BFB3022F8977853BE86B85A293DB8571CCF1D2AD93483AE91803665DC5BDC7B93B1FC38BCA0B8A5EEFFC57DE7E20E8DCCB5422E8C987E2AAEFD3013BEE451266216BF6F3F229B5BC631C3A51FEE19D6564F60824C65B634279274D99FA634D70DACC00DC1F639AC71A3A07EBFDEA1FB11EA833240A877B6055C87D6DC50B4B8A2AAAB8CEEB8CB82194B12CC7DEB6E2B57BCB0B8D8C61FC2E7D3BD2C306864B6B07EED6D6D099B9FADA0B7EB2A14C394A7C64E98650BE6AA3F8EE516B16E2177A4B8B2D6AD55FFEC3789AFE4DDFF4267EB1DEFEF406A3239C5E0249EE33C4EA8FDD9E943AE1B46B8996EA194B1169954BB68699F7641126DFD62658810D09EEBFD2CD1419A7AE4D8CFFA4135A97AFCF535D98174404D766A7EEB9AEC4268B1721BA6B57C3856879ADB689D8D77EE9701C9F5456AEB35D9F5482D2809E6E9297EC0388508F130518F3C766C136E8C05E93B013FFC538C05C7781B8119537C09C616F306C129FAB4F716F0EF99C8A931B1386C2C7FF79989BBA43E39153D73F4688F49EA91A5D1034B7F906CFD631BE90DE6DCFF74B60E181C73775F3F36BE590987A3617FF078F5E05710C988C40B9785C2CD379C0AB7C1BF76641CB26640DB5F48820918BE6A20DCF7120591A3A306B492B9524B5D5514236B7B5489F40A3E03CB62CCFF456AF9924516B72330267F51F8C2448622977201F195BAC96C92D90B63402E44E75D29A0FBEDE77371D7E7E026714FE62D42403739860037EA978C8BB8F67B3A6CF85D10AE15CB338D5EE18B12C2AD3635D2B556070295E99B4002CA31C21DC8442098B951217B8497F886EF479F61C5A24D75F9ED0679BA10DDB40713CE562993A6C468F4DD573FEA3EFB7DFC0A8125B13C28140000 , N'6.1.3-40302')

