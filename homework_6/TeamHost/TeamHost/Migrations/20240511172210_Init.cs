using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamHost.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    Alpha2 = table.Column<string>(type: "text", nullable: false),
                    Alpha3 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ShortDescription = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    StaticFilePath = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeveloperId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Companies_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameCategories",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => new { x.GameId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_GameCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCategories_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaticFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    GameId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticFiles_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ImageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platforms_StaticFiles_ImageId",
                        column: x => x.ImageId,
                        principalTable: "StaticFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GamesId = table.Column<long>(type: "bigint", nullable: false),
                    PlatformsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GamesId, x.PlatformsId });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlatformId = table.Column<long>(type: "bigint", nullable: false),
                    GamePlatformGameId = table.Column<long>(type: "bigint", nullable: true),
                    GamePlatformPlatformId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => new { x.GameId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_GamePlatforms_GamePlatforms_GamePlatformGameId_GamePlatform~",
                        columns: x => new { x.GamePlatformGameId, x.GamePlatformPlatformId },
                        principalTable: "GamePlatforms",
                        principalColumns: new[] { "GameId", "PlatformId" });
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "strategy", "Стратегии", "Strategy" },
                    { 2L, "adventure", "Приключенческие игры", "Adventure" },
                    { 3L, "horror", "Хоррор", "Horror" },
                    { 4L, "simulator", "Симулятор", "Simulator" },
                    { 5L, "fighting", "Файтинг", "Fighting" },
                    { 6L, "survival", "Выживание", "Survival" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2", "Alpha3", "Code", "Fullname", "Name" },
                values: new object[,]
                {
                    { 1L, "AU", "AUS", 36L, "АВСТРАЛИЯ", "АВСТРАЛИЯ" },
                    { 2L, "AT", "AUT", 40L, "АВСТРИЙСКАЯ РЕСПУБЛИКА", "АВСТРИЯ" },
                    { 3L, "AZ", "AZE", 31L, "РЕСПУБЛИКА АЗЕРБАЙДЖАН", "АЗЕРБАЙДЖАН" },
                    { 4L, "AL", "ALB", 8L, "РЕСПУБЛИКА АЛБАНИЯ", "АЛБАНИЯ" },
                    { 5L, "DZ", "DZA", 12L, "АЛЖИРСКАЯ НАРОДНАЯ ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА", "АЛЖИР" },
                    { 6L, "AI", "AIA", 660L, "АНГИЛЬЯ", "АНГИЛЬЯ" },
                    { 7L, "AO", "AGO", 24L, "РЕСПУБЛИКА АНГОЛА", "АНГОЛА" },
                    { 8L, "AD", "AND", 20L, "КНЯЖЕСТВО АНДОРРА", "АНДОРРА" },
                    { 9L, "AQ", "ATA", 10L, "АНТАРКТИДА", "АНТАРКТИДА" },
                    { 10L, "AG", "ATG", 28L, "АНТИГУА И БАРБУДА", "АНТИГУА И БАРБУДА" },
                    { 11L, "AR", "ARG", 32L, "АРГЕНТИНСКАЯ РЕСПУБЛИКА", "АРГЕНТИНА" },
                    { 12L, "AM", "ARM", 51L, "РЕСПУБЛИКА АРМЕНИЯ", "АРМЕНИЯ" },
                    { 13L, "AW", "ABW", 533L, "ОСТРОВ АРУБА", "АРУБА" },
                    { 14L, "AF", "AFG", 4L, "ПЕРЕХОДНОЕ ИСЛАМСКОЕ ГОСУДАРСТВО АФГАНИСТАН", "АФГАНИСТАН" },
                    { 15L, "BS", "BHS", 44L, "СОДРУЖЕСТВО БАГАМЫ", "БАГАМЫ" },
                    { 16L, "BD", "BGD", 50L, "НАРОДНАЯ РЕСПУБЛИКА БАНГЛАДЕШ", "БАНГЛАДЕШ" },
                    { 17L, "BB", "BRB", 52L, "БАРБАДОС", "БАРБАДОС" },
                    { 18L, "BH", "BHR", 48L, "КОРОЛЕВСТВО БАХРЕЙН", "БАХРЕЙН" },
                    { 19L, "BY", "BLR", 112L, "РЕСПУБЛИКА БЕЛАРУСЬ", "БЕЛАРУСЬ" },
                    { 20L, "BZ", "BLZ", 84L, "БЕЛИЗ", "БЕЛИЗ" },
                    { 21L, "BE", "BEL", 56L, "КОРОЛЕВСТВО БЕЛЬГИИ", "БЕЛЬГИЯ" },
                    { 22L, "BJ", "BEN", 204L, "РЕСПУБЛИКА БЕНИН", "БЕНИН" },
                    { 23L, "BM", "BMU", 60L, "БЕРМУДСКИЕ ОСТРОВА", "БЕРМУДЫ" },
                    { 24L, "BG", "BGR", 100L, "РЕСПУБЛИКА БОЛГАРИЯ", "БОЛГАРИЯ" },
                    { 25L, "BO", "BOL", 68L, "РЕСПУБЛИКА БОЛИВИЯ", "БОЛИВИЯ" },
                    { 26L, "BA", "BIH", 70L, "БОСНИЯ И ГЕРЦЕГОВИНА", "БОСНИЯ И ГЕРЦЕГОВИНА" },
                    { 27L, "BW", "BWA", 72L, "РЕСПУБЛИКА БОТСВАНА", "БОТСВАНА" },
                    { 28L, "BR", "BRA", 76L, "ФЕДЕРАТИВНАЯ РЕСПУБЛИКА БРАЗИЛИЯ", "БРАЗИЛИЯ" },
                    { 29L, "IO", "IOT", 86L, "БРИТАНСКАЯ ТЕРРИТОРИЯ В ИНДИЙСКОМ ОКЕАНЕ (БРИТ.)", "БРИТАН. ТЕРРИТ." },
                    { 30L, "BN", "BRN", 96L, "БРУНЕЙ-ДАРУССАЛАМ", "БРУНЕЙ" },
                    { 31L, "BV", "BVT", 74L, "ОСТРОВ БУВЕ", "БУВЕ" },
                    { 32L, "BF", "BFA", 854L, "БУРКИНА-ФАСО", "БУРКИНА-ФАСО" },
                    { 33L, "BI", "BDI", 108L, "РЕСПУБЛИКА БУРУНДИ", "БУРУНДИ" },
                    { 34L, "BT", "BTN", 64L, "КОРОЛЕВСТВО БУТАН", "БУТАН" },
                    { 35L, "VU", "VUT", 548L, "РЕСПУБЛИКА ВАНУАТУ", "ВАНУАТУ" },
                    { 36L, "VA", "VAT", 336L, "ПАПСКИЙ ПРЕСТОЛ (ГОСУДАРСТВО-ГОРОД ВАТИКАН)", "ВАТИКАН" },
                    { 37L, "HU", "HUN", 348L, "ВЕНГЕРСКАЯ РЕСПУБЛИКА", "ВЕНГРИЯ" },
                    { 38L, "VE", "VEN", 862L, "БОЛИВАРИЙСКАЯ РЕСПУБЛИКА ВЕНЕСУЭЛА", "ВЕНЕСУЭЛА" },
                    { 39L, "VI", "VIR", 850L, "ВИРГИНСКИЕ ОСТРОВА (США)", "ВИРГИН. О-ВА" },
                    { 40L, "VG", "VGB", 92L, "БРИТАНСКИЕ ВИРГИНСКИЕ ОСТРОВА", "ВИРГИН. О-ВА, БРИТАНСКИЕ" },
                    { 41L, "AS", "ASM", 16L, "АМЕРИКАНСКОЕ САМОА (США)", "ВОСТОЧНОЕ САМОА" },
                    { 42L, "VN", "VNM", 704L, "СОЦИАЛИСТИЧЕСКАЯ РЕСПУБЛИКА ВЬЕТНАМ", "ВЬЕТНАМ" },
                    { 43L, "GA", "GAB", 266L, "ГАБОНСКАЯ РЕСПУБЛИКА", "ГАБОН" },
                    { 44L, "HT", "HTI", 332L, "РЕСПУБЛИКА ГАИТИ", "ГАИТИ" },
                    { 45L, "GY", "GUY", 328L, "РЕСПУБЛИКА ГАЙАНА", "ГАЙАНА" },
                    { 46L, "GM", "GMB", 270L, "РЕСПУБЛИКА ГАМБИЯ", "ГАМБИЯ" },
                    { 47L, "GH", "GHA", 288L, "РЕСПУБЛИКА ГАНА", "ГАНА" },
                    { 48L, "GP", "GLP", 312L, "ГВАДЕЛУПА (ФР.)", "ГВАДЕЛУПА" },
                    { 49L, "GT", "GTM", 320L, "РЕСПУБЛИКА ГВАТЕМАЛА", "ГВАТЕМАЛА" },
                    { 50L, "GF", "GUF", 254L, "ФРАНЦУЗСКАЯ ГВИАНА (ФР.)", "ГВИАНА" },
                    { 51L, "GN", "GIN", 324L, "ГВИНЕЙСКАЯ РЕСПУБЛИКА", "ГВИНЕЯ" },
                    { 52L, "GW", "GNB", 624L, "РЕСПУБЛИКА ГВИНЕЯ-БИСАУ", "ГВИНЕЯ-БИСАУ" },
                    { 53L, "DE", "DEU", 276L, "ФЕДЕРАТИВНАЯ РЕСПУБЛИКА ГЕРМАНИЯ", "ГЕРМАНИЯ" },
                    { 54L, "GG", "GGY", 831L, "ГЕРНСИ", "ГЕРНСИ" },
                    { 55L, "GI", "GIB", 292L, "ГИБРАЛТАР (БРИТ.)", "ГИБРАЛТАР" },
                    { 56L, "HN", "HND", 340L, "РЕСПУБЛИКА ГОНДУРАС", "ГОНДУРАС" },
                    { 57L, "HK", "HKG", 344L, "СПЕЦИАЛЬНЫЙ АДМИНИСТРАТИВНЫЙ РЕГИОН КИТАЯ ГОНКОНГ", "ГОНКОНГ" },
                    { 58L, "GD", "GRD", 308L, "ГРЕНАДА", "ГРЕНАДА" },
                    { 59L, "GL", "GRL", 304L, "ГРЕНЛАНДИЯ", "ГРЕНЛАНДИЯ" },
                    { 60L, "GR", "GRC", 300L, "ГРЕЧЕСКАЯ РЕСПУБЛИКА", "ГРЕЦИЯ" },
                    { 61L, "GE", "GEO", 268L, "РЕСПУБЛИКА ГРУЗИЯ", "ГРУЗИЯ" },
                    { 62L, "GU", "GUM", 316L, "ГУАМ (США)", "ГУАМ" },
                    { 63L, "DK", "DNK", 208L, "КОРОЛЕВСТВО ДАНИЯ", "ДАНИЯ" },
                    { 64L, "JE", "JEY", 832L, "ДЖЕРСИ", "ДЖЕРСИ" },
                    { 65L, "DJ", "DJI", 262L, "РЕСПУБЛИКА ДЖИБУТИ", "ДЖИБУТИ" },
                    { 66L, "DM", "DMA", 212L, "СОДРУЖЕСТВО ДОМИНИКИ", "ДОМИНИКА" },
                    { 67L, "DO", "DOM", 214L, "ДОМИНИКАНСКАЯ РЕСПУБЛИКА", "ДОМИНИКАНСКАЯ РЕСПУБЛИКА" },
                    { 68L, "EG", "EGY", 818L, "АРАБСКАЯ РЕСПУБЛИКА ЕГИПЕТ (АРЕ)", "ЕГИПЕТ" },
                    { 69L, "ZM", "ZMB", 894L, "РЕСПУБЛИКА ЗАМБИЯ", "ЗАМБИЯ" },
                    { 70L, "EH", "ESH", 732L, "ЗАПАДНАЯ САХАРА", "ЗАПАДНАЯ САХАРА" },
                    { 71L, "ZW", "ZWE", 716L, "РЕСПУБЛИКА ЗИМБАБВЕ", "ЗИМБАБВЕ" },
                    { 72L, "IL", "ISR", 376L, "ГОСУДАРСТВО ИЗРАИЛЬ", "ИЗРАИЛЬ" },
                    { 73L, "IN", "IND", 356L, "РЕСПУБЛИКА ИНДИЯ", "ИНДИЯ" },
                    { 74L, "ID", "IDN", 360L, "РЕСПУБЛИКА ИНДОНЕЗИЯ", "ИНДОНЕЗИЯ" },
                    { 75L, "JO", "JOR", 400L, "ИОРДАНСКОЕ ХАШИМИТСКОЕ КОРОЛЕВСТВО", "ИОРДАНИЯ" },
                    { 76L, "IQ", "IRQ", 368L, "РЕСПУБЛИКА ИРАК", "ИРАК" },
                    { 77L, "IR", "IRN", 364L, "ИСЛАМСКАЯ РЕСПУБЛИКА ИРАН", "ИРАН" },
                    { 78L, "IE", "IRL", 372L, "ИРЛАНДИЯ", "ИРЛАНДИЯ" },
                    { 79L, "IS", "ISL", 352L, "РЕСПУБЛИКА ИСЛАНДИЯ", "ИСЛАНДИЯ" },
                    { 80L, "ES", "ESP", 724L, "КОРОЛЕВСТВО ИСПАНИЯ", "ИСПАНИЯ" },
                    { 81L, "IT", "ITA", 380L, "ИТАЛЬЯНСКАЯ РЕСПУБЛИКА", "ИТАЛИЯ" },
                    { 82L, "YE", "YEM", 887L, "ЙЕМЕНСКАЯ РЕСПУБЛИКА", "ЙЕМЕН" },
                    { 83L, "CV", "CPV", 132L, "РЕСПУБЛИКА КАБО-ВЕРДЕ", "КАБО-ВЕРДЕ" },
                    { 84L, "KZ", "KAZ", 398L, "РЕСПУБЛИКА КАЗАХСТАН", "КАЗАХСТАН" },
                    { 85L, "KY", "CYM", 136L, "ОСТРОВА КАЙМАН", "КАЙМАН" },
                    { 86L, "KH", "KHM", 116L, "КОРОЛЕВСТВО КАМБОДЖА", "КАМБОДЖА" },
                    { 87L, "CM", "CMR", 120L, "РЕСПУБЛИКА КАМЕРУН", "КАМЕРУН" },
                    { 88L, "CA", "CAN", 124L, "КАНАДА", "КАНАДА" },
                    { 89L, "QA", "QAT", 634L, "ГОСУДАРСТВО КАТАР", "КАТАР" },
                    { 91L, "KE", "KEN", 404L, "РЕСПУБЛИКА КЕНИЯ", "КЕНИЯ" },
                    { 92L, "CY", "CYP", 196L, "РЕСПУБЛИКА КИПР", "КИПР" },
                    { 93L, "KI", "KIR", 296L, "РЕСПУБЛИКА КИРИБАТИ", "КИРИБАТИ" },
                    { 94L, "CN", "CHN", 156L, "КИТАЙСКАЯ НАРОДНАЯ РЕСПУБЛИКА (КНР)", "КИТАЙ" },
                    { 95L, "CC", "CCK", 166L, "КОКОСОВЫЕ (КИЛИНГ) ОСТРОВА", "КОКОСОВЫЕ О-ВА" },
                    { 96L, "CO", "COL", 170L, "РЕСПУБЛИКА КОЛУМБИЯ", "КОЛУМБИЯ" },
                    { 97L, "KM", "COM", 174L, "СОЮЗ КОМОРЫ", "КОМОРЫ" },
                    { 98L, "CG", "COG", 178L, "РЕСПУБЛИКА КОНГО", "КОНГО" },
                    { 99L, "CD", "COD", 180L, "ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА КОНГО", "КОНГО" },
                    { 100L, "KR", "KOR", 410L, "РЕСПУБЛИКА КОРЕЯ", "КОРЕЯ" },
                    { 101L, "KP", "PRK", 408L, "КОРЕЙСКАЯ НАРОДНО-ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА", "КОРЕЯ (КНДР)" },
                    { 102L, "CR", "CRI", 188L, "РЕСПУБЛИКА КОСТА-РИКА", "КОСТА-РИКА" },
                    { 103L, "CI", "CIV", 384L, "РЕСПУБЛИКА КОТ Д'ИВУАР'", "КОТ Д'ИВУАР'" },
                    { 104L, "CU", "CUB", 192L, "РЕСПУБЛИКА КУБА", "КУБА" },
                    { 105L, "KW", "KWT", 414L, "ГОСУДАРСТВО КУВЕЙТ", "КУВЕЙТ" },
                    { 106L, "KG", "KGZ", 417L, "РЕСПУБЛИКА КЫРГЫЗСТАН", "КЫРГЫЗСТАН" },
                    { 107L, "LA", "LAO", 418L, "ЛАОССКАЯ НАРОДНО-ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА", "ЛАОС" },
                    { 108L, "LV", "LVA", 428L, "ЛАТВИЙСКАЯ РЕСПУБЛИКА", "ЛАТВИЯ" },
                    { 109L, "LS", "LSO", 426L, "КОРОЛЕВСТВО ЛЕСОТО", "ЛЕСОТО" },
                    { 110L, "LR", "LBR", 430L, "РЕСПУБЛИКА ЛИБЕРИЯ", "ЛИБЕРИЯ" },
                    { 111L, "LB", "LBN", 422L, "ЛИВАНСКАЯ РЕСПУБЛИКА", "ЛИВАН" },
                    { 112L, "LY", "LBY", 434L, "СОЦИАЛИСТИЧЕСКАЯ НАРОДНАЯ ЛИВИЙСКАЯ АРАБСКАЯ ДЖАМАХИРИЯ", "ЛИВИЯ" },
                    { 113L, "LT", "LTU", 440L, "ЛИТОВСКАЯ РЕСПУБЛИКА", "ЛИТВА" },
                    { 114L, "LI", "LIE", 438L, "КНЯЖЕСТВО ЛИХТЕНШТЕЙН", "ЛИХТЕНШТЕЙН" },
                    { 115L, "LU", "LUX", 442L, "ВЕЛИКОЕ ГЕРЦОГСТВО ЛЮКСЕМБУРГ", "ЛЮКСЕМБУРГ" },
                    { 116L, "MU", "MUS", 480L, "РЕСПУБЛИКА МАВРИКИЙ", "МАВРИКИЙ" },
                    { 117L, "MR", "MRT", 478L, "ИСЛАМСКАЯ РЕСПУБЛИКА МАВРИТАНИЯ", "МАВРИТАНИЯ" },
                    { 118L, "MG", "MDG", 450L, "ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА МАДАГАСКАР", "МАДАГАСКАР" },
                    { 119L, "YT", "MYT", 175L, "МАЙОТТА", "МАЙОТТА" },
                    { 120L, "MO", "MAC", 446L, "СПЕЦИАЛЬНЫЙ АДМИНИСТРАТИВНЫЙ РЕГИОН КИТАЯ МАКАО", "МАКАО" },
                    { 121L, "MK", "MKD", 807L, "РЕСПУБЛИКА МАКЕДОНИЯ", "МАКЕДОНИЯ" },
                    { 122L, "MW", "MWI", 454L, "РЕСПУБЛИКА МАЛАВИ", "МАЛАВИ" },
                    { 123L, "MY", "MYS", 458L, "МАЛАЙЗИЯ", "МАЛАЙЗИЯ" },
                    { 124L, "ML", "MLI", 466L, "РЕСПУБЛИКА МАЛИ", "МАЛИ" },
                    { 125L, "UM", "UMI", 581L, "МАЛЫЕ ТИХООКЕАНСКИЕ ОТДАЛЕННЫЕ ОСТРОВА (США)", "МАЛЫЕ ТИХООК. ОСТРОВА (США)" },
                    { 126L, "MV", "MDV", 462L, "МАЛЬДИВСКАЯ РЕСПУБЛИКА", "МАЛЬДИВЫ" },
                    { 127L, "MT", "MLT", 470L, "РЕСПУБЛИКА МАЛЬТА", "МАЛЬТА" },
                    { 128L, "MP", "MNP", 580L, "СОДРУЖЕСТВО СЕВЕРНЫХ МАРИАНСКИХ ОСТРОВОВ", "МАРИАНСКИЕ ОСТРОВА" },
                    { 129L, "MA", "MAR", 504L, "КОРОЛЕВСТВО МАРОККО", "МАРОККО" },
                    { 130L, "MQ", "MTQ", 474L, "МАРТИНИКА (ФР.)", "МАРТИНИКА" },
                    { 131L, "MH", "MHL", 584L, "РЕСПУБЛИКА МАРШАЛЛОВЫ ОСТРОВА", "МАРШАЛЛОВЫ ОСТРОВА" },
                    { 132L, "MX", "MEX", 484L, "МЕКСИКАНСКИЕ СОЕДИНЕННЫЕ ШТАТЫ", "МЕКСИКА" },
                    { 133L, "FM", "FSM", 583L, "ФЕДЕРАТИВНЫЕ ШТАТЫ МИКРОНЕЗИИ", "МИКРОНЕЗИЯ" },
                    { 134L, "MZ", "MOZ", 508L, "РЕСПУБЛИКА МОЗАМБИК", "МОЗАМБИК" },
                    { 135L, "MD", "MDA", 498L, "РЕСПУБЛИКА МОЛДОВА", "МОЛДОВА" },
                    { 136L, "MC", "MCO", 492L, "КНЯЖЕСТВО МОНАКО", "МОНАКО" },
                    { 137L, "MN", "MHG", 496L, "МОНГОЛИЯ", "МОНГОЛИЯ" },
                    { 138L, "MS", "MSR", 500L, "МОНТСЕРРАТ (БРИТ.)", "МОНТСЕРРАТ" },
                    { 139L, "MM", "MMR", 104L, "СОЮЗ МЬЯНМА", "МЬЯНМА" },
                    { 140L, "NA", "NAM", 516L, "РЕСПУБЛИКА НАМИБИЯ", "НАМИБИЯ" },
                    { 141L, "NR", "NRU", 520L, "РЕСПУБЛИКА НАУРУ", "НАУРУ" },
                    { 142L, "NP", "NPL", 524L, "КОРОЛЕВСТВО НЕПАЛ", "НЕПАЛ" },
                    { 143L, "NE", "NER", 562L, "РЕСПУБЛИКА НИГЕР", "НИГЕР" },
                    { 144L, "NG", "NGA", 566L, "ФЕДЕРАТИВНАЯ РЕСПУБЛИКА НИГЕРИЯ", "НИГЕРИЯ" },
                    { 145L, "AN", "ANT", 530L, "НИДЕРЛАНДСКИЕ АНТИЛЫ", "НИДЕРЛАНДСКИЕ АНТИЛЫ" },
                    { 146L, "NL", "NLD", 528L, "КОРОЛЕВСТВО НИДЕРЛАНДЫ", "НИДЕРЛАНДЫ" },
                    { 147L, "NI", "NIC", 558L, "РЕСПУБЛИКА НИКАРАГУА", "НИКАРАГУА" },
                    { 148L, "NU", "NIU", 570L, "РЕСПУБЛИКА НИУЭ", "НИУЭ" },
                    { 149L, "NZ", "NZL", 554L, "НОВАЯ ЗЕЛАНДИЯ", "НОВАЯ ЗЕЛАНДИЯ" },
                    { 150L, "NC", "NCL", 540L, "НОВАЯ КАЛЕДОНИЯ", "НОВАЯ КАЛЕДОНИЯ" },
                    { 151L, "NO", "NOR", 578L, "КОРОЛЕВСТВО НОРВЕГИЯ", "НОРВЕГИЯ" },
                    { 152L, "NF", "NFK", 574L, "ОСТРОВ НОРФОЛК", "НОРФОЛК" },
                    { 153L, "AE", "ARE", 784L, "ОБЪЕДИНЕННЫЕ АРАБСКИЕ ЭМИРАТЫ", "ОБЪЕД. АРАБСКИЕ ЭМИРАТЫ" },
                    { 154L, "IM", "IMY", 833L, "ОСТРОВ МЭН", "О-В МЭН" },
                    { 155L, "CX", "CXR", 162L, "ОСТРОВ РОЖДЕСТВА (АВСТРАЛ.)", "О-В РОЖДЕСТВА" },
                    { 156L, "СК", "COK", 184L, "ОСТРОВА КУКА (Н. ЗЕЛ.)", "О-ВА КУКА" },
                    { 157L, "OM", "OMN", 512L, "СУЛТАНАТ ОМАН", "ОМАН" },
                    { 158L, "PK", "PAK", 586L, "ИСЛАМСКАЯ РЕСПУБЛИКА ПАКИСТАН", "ПАКИСТАН" },
                    { 159L, "PW", "PLW", 585L, "РЕСПУБЛИКА ПАЛАУ", "ПАЛАУ" },
                    { 160L, "PS", "PSE", 275L, "ОККУПИРОВАННАЯ ПАЛЕСТИНСКАЯ ТЕРРИТОРИЯ", "ПАЛЕСТИНСКАЯ ТЕРРИТОРИЯ, ОККУПИРОВАННАЯ" },
                    { 161L, "PA", "PAN", 591L, "РЕСПУБЛИКА ПАНАМА", "ПАНАМА" },
                    { 162L, "PG", "PNG", 598L, "ПАПУА - НОВАЯ ГВИНЕЯ", "ПАПУА - НОВАЯ ГВИНЕЯ" },
                    { 163L, "PY", "PRY", 600L, "РЕСПУБЛИКА ПАРАГВАЙ", "ПАРАГВАЙ" },
                    { 164L, "PE", "PER", 604L, "РЕСПУБЛИКА ПЕРУ", "ПЕРУ" },
                    { 165L, "PN", "PCN", 612L, "ПИТКЭРН (БРИТ.)", "ПИТКЭРН" },
                    { 166L, "PL", "POL", 616L, "РЕСПУБЛИКА ПОЛЬША", "ПОЛЬША" },
                    { 167L, "PT", "PRT", 620L, "ПОРТУГАЛЬСКАЯ РЕСПУБЛИКА", "ПОРТУГАЛИЯ" },
                    { 168L, "PR", "PRI", 630L, "ПУЭРТО-РИКО", "ПУЭРТО-РИКО" },
                    { 169L, "RE", "REU", 638L, "РЕЮНЬОН", "РЕЮНЬОН" },
                    { 170L, "RU", "RUS", 643L, "РОССИЙСКАЯ ФЕДЕРАЦИЯ", "РОССИЯ" },
                    { 171L, "RW", "RWA", 646L, "РУАНДИЙСКАЯ РЕСПУБЛИКА", "РУАНДА" },
                    { 172L, "RO", "ROM", 642L, "РУМЫНИЯ", "РУМЫНИЯ" },
                    { 173L, "WS", "WSM", 882L, "НЕЗАВИСИМОЕ ГОСУДАРСТВО САМОА", "САМОА" },
                    { 174L, "ST", "STR", 678L, "ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА САН-ТОМЕ И ПРИНСИПИ", "САН-ТОМЕ И ПРИНСИПИ" },
                    { 175L, "SM", "SMR", 674L, "РЕСПУБЛИКА САН-МАРИНО", "САН-МАРИНО" },
                    { 176L, "SA", "SAU", 682L, "КОРОЛЕВСТВО САУДОВСКАЯ АРАВИЯ", "САУДОВСКАЯ АРАВИЯ" },
                    { 177L, "SZ", "SWZ", 748L, "КОРОЛЕВСТВО СВАЗИЛЕНД", "СВАЗИЛЕНД" },
                    { 178L, "SH", "SHN", 654L, "ОСТРОВ СВЯТОЙ ЕЛЕНЫ (БРИТ.)", "СВЯТАЯ ЕЛЕНА" },
                    { 179L, "SC", "SYC", 690L, "РЕСПУБЛИКА СЕЙШЕЛЫ", "СЕЙШЕЛЫ" },
                    { 180L, "PM", "SPM", 666L, "СЕН-ПЬЕР И МИКЕЛОН (ФР.)", "СЕН-ПЬЕР И МИКЕЛОН" },
                    { 181L, "SN", "SEN", 686L, "РЕСПУБЛИКА СЕНЕГАЛ", "СЕНЕГАЛ" },
                    { 182L, "VC", "VCT", 670L, "СЕНТ-ВИНСЕНТ И ГРЕНАДИНЫ", "СЕНТ-ВИНСЕНТ И ГРЕНАДИНЫ" },
                    { 183L, "KN", "KNA", 659L, "ФЕДЕРАЦИЯ СЕНТ-КИТС (СЕНТ-КРИСТОФЕР) И НЕВИС", "СЕНТ-КИТС И НЕВИС" },
                    { 184L, "LC", "LCA", 662L, "СЕНТ-ЛЮСИЯ", "СЕНТ-ЛЮСИЯ" },
                    { 185L, "RS", "SRB", 688L, "РЕСПУБЛИКА СЕРБИЯ", "СЕРБИЯ" },
                    { 186L, "SG", "SGP", 702L, "РЕСПУБЛИКА СИНГАПУР", "СИНГАПУР" },
                    { 187L, "SY", "SYR", 760L, "СИРИЙСКАЯ АРАБСКАЯ РЕСПУБЛИКА", "СИРИЯ" },
                    { 188L, "SK", "SVK", 703L, "СЛОВАЦКАЯ РЕСПУБЛИКА", "СЛОВАКИЯ" },
                    { 189L, "SI", "SVN", 705L, "РЕСПУБЛИКА СЛОВЕНИЯ", "СЛОВЕНИЯ" },
                    { 190L, "GB", "GBR", 826L, "СОЕДИНЕННОЕ КОРОЛЕВСТВО ВЕЛИКОБРИТАНИИ И СЕВЕРНОЙ ИРЛАНДИИ", "СОЕДИНЕННОЕ КОРОЛЕВСТВО" },
                    { 191L, "SB", "SLB", 90L, "СОЛОМОНОВЫ ОСТРОВА", "СОЛОМОНОВЫ О-ВА" },
                    { 192L, "SO", "SOM", 706L, "СОМАЛИЙСКАЯ РЕСПУБЛИКА", "СОМАЛИ" },
                    { 193L, "SD", "SDN", 736L, "РЕСПУБЛИКА СУДАН", "СУДАН" },
                    { 194L, "SR", "SUR", 740L, "РЕСПУБЛИКА СУРИНАМ", "СУРИНАМ" },
                    { 195L, "US", "USA", 840L, "СОЕДИНЕННЫЕ ШТАТЫ АМЕРИКИ", "США" },
                    { 196L, "SL", "SLE", 694L, "РЕСПУБЛИКА СЬЕРРА-ЛЕОНЕ", "СЬЕРРА-ЛЕОНЕ" },
                    { 197L, "TJ", "TJK", 762L, "РЕСПУБЛИКА ТАДЖИКИСТАН", "ТАДЖИКИСТАН" },
                    { 198L, "TH", "THA", 764L, "КОРОЛЕВСТВО ТАИЛАНД", "ТАИЛАНД" },
                    { 199L, "TW", "TWN", 158L, "ТАЙВАНЬ (В СОСТАВЕ КИТАЯ)", "ТАЙВАНЬ" },
                    { 200L, "TZ", "TZA", 834L, "ОБЪЕДИНЕННАЯ РЕСПУБЛИКА ТАНЗАНИЯ (ОРТ)", "ТАНЗАНИЯ" },
                    { 201L, "TC", "TCA", 796L, "ОСТРОВА ТЕРКС И КАЙКОС (БРИТ.)", "ТЕРКС И КАЙКОС" },
                    { 202L, "TP", "TMP", 626L, "ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА ТИМОР-ЛЕСТЕ", "ТИМОР-ЛЕСТЕ" },
                    { 203L, "TG", "TGO", 768L, "ТОГОЛЕЗСКАЯ РЕСПУБЛИКА", "ТОГО" },
                    { 204L, "TK", "TKL", 772L, "ТОКЕЛАУ (ЮНИОН) (Н. ЗЕЛ.)", "ТОКЕЛАУ" },
                    { 205L, "TO", "TON", 776L, "КОРОЛЕВСТВО ТОНГА", "ТОНГА" },
                    { 206L, "TT", "TTO", 780L, "РЕСПУБЛИКА ТРИНИДАД И ТОБАГО", "ТРИНИДАД И ТОБАГО" },
                    { 207L, "TV", "TUV", 798L, "ТУВАЛУ", "ТУВАЛУ" },
                    { 208L, "TN", "TUN", 788L, "ТУНИССКАЯ РЕСПУБЛИКА", "ТУНИС" },
                    { 209L, "TM", "TKM", 795L, "ТУРКМЕНИСТАН", "ТУРКМЕНИЯ" },
                    { 210L, "TR", "TUR", 792L, "ТУРЕЦКАЯ РЕСПУБЛИКА", "ТУРЦИЯ" },
                    { 211L, "UG", "UGA", 800L, "РЕСПУБЛИКА УГАНДА", "УГАНДА" },
                    { 212L, "UZ", "UZB", 860L, "РЕСПУБЛИКА УЗБЕКИСТАН", "УЗБЕКИСТАН" },
                    { 213L, "UA", "UKR", 804L, "УКРАИНА", "УКРАИНА" },
                    { 214L, "WF", "WLF", 876L, "ОСТРОВА УОЛЛИС И ФУТУНА", "УОЛЛИС И ФУТУНА" },
                    { 215L, "UY", "URY", 858L, "ВОСТОЧНАЯ РЕСПУБЛИКА УРУГВАЙ", "УРУГВАЙ" },
                    { 216L, "FO", "FRO", 234L, "ФАРЕРСКИЕ ОСТРОВА (В СОСТАВЕ ДАНИИ)", "ФАРЕРСКИЕ О-ВА" },
                    { 217L, "FJ", "FJI", 242L, "РЕСПУБЛИКА ОСТРОВОВ ФИДЖИ", "ФИДЖИ" },
                    { 218L, "PH", "PHL", 608L, "РЕСПУБЛИКА ФИЛИППИНЫ", "ФИЛИППИНЫ" },
                    { 219L, "FI", "FIN", 246L, "ФИНЛЯНДСКАЯ РЕСПУБЛИКА", "ФИНЛЯНДИЯ" },
                    { 220L, "FK", "FLK", 238L, "ФОЛКЛЕНДСКИЕ ОСТРОВА (МАЛЬВИНСКИЕ)", "ФОЛКЛЕНДСКИЕ О-ВА" },
                    { 221L, "TF", "ATF", 260L, "ФРАНЦУЗСКИЕ ЮЖНЫЕ ТЕРРИТОРИИ (ФР.)", "ФР. ЮЖНЫЕ ТЕРРИТОРИИ" },
                    { 222L, "FR", "FRA", 250L, "ФРАНЦУЗСКАЯ РЕСПУБЛИКА", "ФРАНЦИЯ" },
                    { 223L, "PF", "PYF", 258L, "ФРАНЦУЗСКАЯ ПОЛИНЕЗИЯ (ФР.)", "ФРАНЦУЗСКАЯ ПОЛИНЕЗИЯ" },
                    { 224L, "HM", "HMD", 334L, "ОСТРОВ ХЕРД И ОСТРОВА МАКДОНАЛЬД", "ХЕРД И МАКДОНАЛЬД" },
                    { 225L, "HR", "HRV", 191L, "РЕСПУБЛИКА ХОРВАТИЯ", "ХОРВАТИЯ" },
                    { 226L, "CF", "CAF", 140L, "ЦЕНТРАЛЬНО-АФРИКАНСКАЯ РЕСПУБЛИКА (ЦАР)", "ЦЕНТР. - АФР. РЕСПУБЛИКА" },
                    { 227L, "TD", "TCD", 148L, "РЕСПУБЛИКА ЧАД", "ЧАД" },
                    { 228L, "ME", "MNE", 499L, "РЕСПУБЛИКА ЧЕРНОГОРИЯ", "ЧЕРНОГОРИЯ" },
                    { 229L, "CZ", "CZE", 203L, "ЧЕШСКАЯ РЕСПУБЛИКА", "ЧЕХИЯ" },
                    { 230L, "CL", "CHL", 152L, "РЕСПУБЛИКА ЧИЛИ", "ЧИЛИ" },
                    { 231L, "CH", "CHE", 756L, "ШВЕЙЦАРСКАЯ КОНФЕДЕРАЦИЯ", "ШВЕЙЦАРИЯ" },
                    { 232L, "SE", "SWE", 752L, "КОРОЛЕВСТВО ШВЕЦИЯ", "ШВЕЦИЯ" },
                    { 233L, "SJ", "SJM", 744L, "ШПИЦБЕРГЕН И ЯН-МАЙЕН (НОРВ.)", "ШПИЦБЕРГЕН И ЯН-МАЙЕН" },
                    { 234L, "LK", "LKA", 144L, "ДЕМОКРАТИЧЕСКАЯ СОЦИАЛИСТИЧЕСКАЯ РЕСПУБЛИКА ШРИ-ЛАНКА", "ШРИ-ЛАНКА" },
                    { 235L, "EC", "ECU", 218L, "РЕСПУБЛИКА ЭКВАДОР", "ЭКВАДОР" },
                    { 236L, "GQ", "GNQ", 226L, "РЕСПУБЛИКА ЭКВАТОРИАЛЬНАЯ ГВИНЕЯ", "ЭКВАТОРИАЛЬНАЯ ГВИНЕЯ" },
                    { 237L, "AX", "ALA", 248L, "ЭЛАНДСКИЕ ОСТРОВА", "ЭЛАНДСКИЕ ОСТРОВА" },
                    { 238L, "SV", "SLV", 222L, "РЕСПУБЛИКА ЭЛ-САЛЬВАДОР", "ЭЛЬ-САЛЬВАДОР" },
                    { 239L, "ER", "ERI", 232L, "ЭРИТРЕЯ", "ЭРИТРЕЯ" },
                    { 240L, "EE", "EST", 233L, "ЭСТОНСКАЯ РЕСПУБЛИКА", "ЭСТОНИЯ" },
                    { 241L, "ET", "ETH", 231L, "ФЕДЕРАТИВНАЯ ДЕМОКРАТИЧЕСКАЯ  РЕСПУБЛИКА ЭФИОПИЯ", "ЭФИОПИЯ" },
                    { 242L, "ZA", "ZAF", 710L, "ЮЖНО-АФРИКАНСКАЯ РЕСПУБЛИКА", "ЮЖНАЯ АФРИКА" },
                    { 243L, "GS", "SGS", 239L, "ЮЖНАЯ ДЖОРДЖИЯ И ЮЖНЫЕ САНДВИЧЕВЫ ОСТРОВА", "ЮЖНАЯ ДЖОРДЖИЯ И ЮЖНЫЕ САНДВИЧЕВЫ ОСТРОВА" },
                    { 244L, "JM", "JAM", 388L, "ЯМАЙКА", "ЯМАЙКА" },
                    { 245L, "JP", "JPN", 392L, "ЯПОНИЯ", "ЯПОНИЯ" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Code", "ImageId", "Name" },
                values: new object[,]
                {
                    { 1L, "windows", null, "Windows" },
                    { 2L, "apple", null, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "StaticFiles",
                columns: new[] { "Id", "Extension", "GameId", "Name", "Path", "Size" },
                values: new object[,]
                {
                    { 1L, null, null, "civilization-vi.jpeg", "~/img/games/civilization-vi.jpeg", 10 },
                    { 2L, null, null, "the-witcher-3.jpeg", "~/img/games/the-witcher-3.jpeg", 11 },
                    { 3L, null, null, "among-us.jpeg", "~/img/games/among-us.jpeg", 8 },
                    { 4L, null, null, "gta5.jpeg", "~/img/games/gta5.jpeg", 16 },
                    { 5L, null, null, "re-village.jpeg", "~/img/games/re-village.jpeg", 7 },
                    { 6L, null, null, "stardew-valley.jpeg", "~/img/games/stardew-valley.jpeg", 16 },
                    { 7L, null, null, "dark-souls-3.jpeg", "~/img/games/dark-souls-3.jpeg", 10 },
                    { 8L, null, null, "dead-by-daylight.jpeg", "~/img/games/dead-by-daylight.jpeg", 11 },
                    { 9L, null, null, "the-last-of-us.jpeg", "~/img/games/the-last-of-us.jpeg", 9 },
                    { 10L, null, null, "minecraft.jpeg", "~/img/games/minecraft.jpeg", 17 }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CountryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, 195L, "Firaxis Games is an American video game developer.", "Firaxis Games" },
                    { 2L, 166L, "CD Projekt Red is a Polish video game developer.", "CD Projekt Red" },
                    { 3L, 195L, "InnerSloth is an independent game development studio.", "InnerSloth" },
                    { 4L, 190L, "Rockstar North is a British video game developer.", "Rockstar North" },
                    { 5L, 245L, "Capcom is a Japanese video game developer and publisher.", "Capcom" },
                    { 6L, 195L, "ConcernedApe is an independent video game developer.", "ConcernedApe" },
                    { 7L, 245L, "FromSoftware is a Japanese video game development company.", "FromSoftware" },
                    { 8L, 88L, "Behaviour Interactive is a Canadian video game development studio.", "Behaviour Interactive" },
                    { 9L, 195L, "Naughty Dog is an American video game developer.", "Naughty Dog" },
                    { 10L, 232L, "Mojang Studios is a Swedish video game developer.", "Mojang Studios" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DeveloperId", "Name", "Price", "Rating", "ReleaseDate", "ShortDescription", "StaticFilePath" },
                values: new object[,]
                {
                    { 1L, "Build an empire to stand the test of time.", 1L, "Civilization VI", 999m, 4.5f, new DateTime(2016, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build an empire to stand the test of time.", "~/img/games/civilization-vi.jpeg" },
                    { 2L, "Hunt down the Child of Prophecy in a vast open world.", 2L, "The Witcher 3: Wild Hunt", 1499m, 4.8f, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunt down the Child of Prophecy in a vast open world.", "~/img/games/the-witcher-3.jpeg" },
                    { 3L, "An online multiplayer social deduction game.", 3L, "Among Us", 499m, 4.7f, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Online multiplayer social deduction game.", "~/img/games/among-us.jpeg" },
                    { 4L, "An action-adventure game played from either a first-person or third-person perspective.", 4L, "Grand Theft Auto V", 1999m, 4.9f, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action-adventure game.", "~/img/games/gta5.jpeg" },
                    { 5L, "A survival horror game developed and published by Capcom.", 5L, "Resident Evil Village", 2799m, 4.6f, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Survival horror game.", "~/img/games/re-village.jpeg" },
                    { 6L, "A farming simulation game.", 6L, "Stardew Valley", 699m, 4.7f, new DateTime(2016, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Farming simulation game.", "~/img/games/stardew-valley.jpeg" },
                    { 7L, "An action role-playing game set in a third-person perspective.", 7L, "Dark Souls III", 2399m, 4.9f, new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action role-playing game.", "~/img/games/dark-souls-3.jpeg" },
                    { 8L, "An asymmetrical multiplayer horror game.", 8L, "Dead by Daylight", 1499m, 4.6f, new DateTime(2016, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asymmetrical multiplayer horror game.", "~/img/games/dead-by-daylight.jpeg" },
                    { 9L, "An action-adventure game set in a post-apocalyptic world.", 9L, "The Last of Us Part II", 2999m, 4.7f, new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action-adventure game.", "~/img/games/the-last-of-us-2.jpeg" },
                    { 10L, "A sandbox video game developed and published by Mojang Studios.", 10L, "Minecraft", 1999m, 4.6f, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandbox video game.", "~/img/games/minecraft.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "CategoryId", "GameId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 1L, 3L },
                    { 2L, 4L },
                    { 3L, 5L },
                    { 4L, 6L },
                    { 2L, 7L },
                    { 3L, 8L },
                    { 2L, 9L },
                    { 2L, 10L }
                });

            migrationBuilder.InsertData(
                table: "GamePlatforms",
                columns: new[] { "GameId", "PlatformId", "GamePlatformGameId", "GamePlatformPlatformId" },
                values: new object[,]
                {
                    { 1L, 1L, null, null },
                    { 2L, 1L, null, null },
                    { 3L, 1L, null, null },
                    { 4L, 1L, null, null },
                    { 5L, 1L, null, null },
                    { 6L, 1L, null, null },
                    { 7L, 1L, null, null },
                    { 8L, 1L, null, null },
                    { 9L, 2L, null, null },
                    { 10L, 1L, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_CategoryId",
                table: "GameCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_GamePlatformGameId_GamePlatformPlatformId",
                table: "GamePlatforms",
                columns: new[] { "GamePlatformGameId", "GamePlatformPlatformId" });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_PlatformId",
                table: "GamePlatforms",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_ImageId",
                table: "Platforms",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticFiles_GameId",
                table: "StaticFiles",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCategories");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "GamePlatforms");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "StaticFiles");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
