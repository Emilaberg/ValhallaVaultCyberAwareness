using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SegmentModel> Segments { get; set; }
        public DbSet<SubCategoryModel> SubCategories { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<PromptModel> Prompts { get; set; }
        public DbSet<ApplicationUserQuestionModel> ApplicationUserQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserQuestionModel>().HasKey(e => new { e.ApplicationUserId, e.QuestionModelId });



            builder.Entity<CategoryModel>().HasData(
            new CategoryModel
            {
                Id = 1,
                CategoryName = "Att skydda sig mot bedr�gerier",


            },
            new CategoryModel
            {
                Id = 2,
                CategoryName = "Cybers�kerhet f�r f�retag",

            },
            new CategoryModel
            {
                Id = 3,
                CategoryName = "Cyberspionage",

            });

            ////Seedad Segments
            builder.Entity<SegmentModel>().HasData(

            // Segments for category 1
            new SegmentModel
            {
                Id = 1,
                SegmentName = "Del 1",

                CategoryId = 1
            },
            new SegmentModel
            {
                Id = 2,
                SegmentName = "Del 2",

                CategoryId = 1
            },
            new SegmentModel
            {
                Id = 3,
                SegmentName = "Del 3",

                CategoryId = 1
            },

            // Segments for category 2
            new SegmentModel
            {
                Id = 4,
                SegmentName = "Del 1",

                CategoryId = 2
            },
            new SegmentModel
            {
                Id = 5,
                SegmentName = "Del 2",

                CategoryId = 2
            },
            new SegmentModel
            {
                Id = 6,
                SegmentName = "Del 3",

                CategoryId = 2
            },
            new SegmentModel
            {
                Id = 7,
                SegmentName = "Del 4",

                CategoryId = 2
            },

            // Segments for category 3
            new SegmentModel
            {
                Id = 8,
                SegmentName = "Del 1",

                CategoryId = 3
            },
            new SegmentModel
            {
                Id = 9,
                SegmentName = "Del 2",

                CategoryId = 3
            },
            new SegmentModel
            {
                Id = 10,
                SegmentName = "Del 3",

                CategoryId = 3
            });

            //Seeding Subcategories
            builder.Entity<SubCategoryModel>().HasData(

            // Category 1 - "Att skydda sig mot bedr�gerier"
            // Subcategories for Segment "Del 1"
            new SubCategoryModel { Id = 1, SubCategoryName = "Kreditkortsbedr�geri", SegmentId = 1 },
            new SubCategoryModel { Id = 2, SubCategoryName = "S�kerhets�tg�rder mot bedr�gerier", SegmentId = 1 },
            new SubCategoryModel { Id = 3, SubCategoryName = "Kommunikationsmetoder", SegmentId = 1 },
            new SubCategoryModel { Id = 4, SubCategoryName = "Telefonbedr�geriers f�rebyggande", SegmentId = 1 },
            new SubCategoryModel { Id = 5, SubCategoryName = "Romansbedr�geri", SegmentId = 1 },
            new SubCategoryModel { Id = 6, SubCategoryName = "Investeringsbedr�geri", SegmentId = 1 },
            new SubCategoryModel { Id = 7, SubCategoryName = "Telefonbedr�geri", SegmentId = 1 },

            // Subcategories for Segment "Del 2"
            new SubCategoryModel { Id = 8, SubCategoryName = "Bedr�gerier i hemmet", SegmentId = 2 },
            new SubCategoryModel { Id = 9, SubCategoryName = "Identitetsst�ld", SegmentId = 2 },
            new SubCategoryModel { Id = 10, SubCategoryName = "N�tfiske och bluffmejl", SegmentId = 2 },
            new SubCategoryModel { Id = 11, SubCategoryName = "Investeringsbedr�geri p� n�tet", SegmentId = 2 },

            // Subcategories for Segment "Del 3"
            new SubCategoryModel { Id = 12, SubCategoryName = "Abonnemangsf�llor och falska fakturor", SegmentId = 3 },
            new SubCategoryModel { Id = 13, SubCategoryName = "Ransomware", SegmentId = 3 },
            new SubCategoryModel { Id = 14, SubCategoryName = "Statistik och f�rh�llningss�tt", SegmentId = 3 },


            // Category 2 - "Cybers�kerhet f�r f�retag"
            // Subcategories for Segment "Del 1"
            new SubCategoryModel { Id = 15, SubCategoryName = "Digital s�kerhet p� f�retag", SegmentId = 4 },
            new SubCategoryModel { Id = 16, SubCategoryName = "L�senordshantering", SegmentId = 4 },
            new SubCategoryModel { Id = 17, SubCategoryName = "S�ker fj�rr�tkomst", SegmentId = 4 },
            new SubCategoryModel { Id = 18, SubCategoryName = "E-posts�kerhet", SegmentId = 4 },
            new SubCategoryModel { Id = 19, SubCategoryName = "Risker och beredskap", SegmentId = 4 },
            new SubCategoryModel { Id = 20, SubCategoryName = "Akt�rer inom cyberbrott", SegmentId = 4 },
            new SubCategoryModel { Id = 21, SubCategoryName = "�kad digital n�rvaro och distansarbete", SegmentId = 4 },
            new SubCategoryModel { Id = 22, SubCategoryName = "Cyberangrepp mot k�nsliga sektorer", SegmentId = 4 },
            new SubCategoryModel { Id = 23, SubCategoryName = "Cyberr�net mot Mersk", SegmentId = 4 },

            // Subcategories for Segment "Del 2"
            new SubCategoryModel { Id = 24, SubCategoryName = "Social engineering", SegmentId = 5 },
            new SubCategoryModel { Id = 25, SubCategoryName = "N�tfiske och skr�ppost", SegmentId = 5 },
            new SubCategoryModel { Id = 26, SubCategoryName = "Vishing", SegmentId = 5 },
            new SubCategoryModel { Id = 27, SubCategoryName = "Varning f�r vishing", SegmentId = 5 },
            new SubCategoryModel { Id = 28, SubCategoryName = "Identifiera VD-mejl", SegmentId = 5 },
            new SubCategoryModel { Id = 29, SubCategoryName = "�neangrepp och presentkortsbluffar", SegmentId = 5 },

            // Subcategories for Segment "Del 3"
            new SubCategoryModel { Id = 30, SubCategoryName = "Virus, maskar och trojaner", SegmentId = 6 },
            new SubCategoryModel { Id = 31, SubCategoryName = "S� kan det g� till", SegmentId = 6 },
            new SubCategoryModel { Id = 32, SubCategoryName = "N�tverksintr�ng", SegmentId = 6 },
            new SubCategoryModel { Id = 33, SubCategoryName = "Dataintr�ng", SegmentId = 6 },
            new SubCategoryModel { Id = 34, SubCategoryName = "Hackad!", SegmentId = 6 },
            new SubCategoryModel { Id = 35, SubCategoryName = "V�garna in", SegmentId = 6 },

            // Subcategories for Segment "Del 4"
            new SubCategoryModel { Id = 36, SubCategoryName = "Utpressningsvirus", SegmentId = 7 },
            new SubCategoryModel { Id = 37, SubCategoryName = "Attacker mot servrar", SegmentId = 7 },
            new SubCategoryModel { Id = 38, SubCategoryName = "Cyberangrepp i Norden", SegmentId = 7 },
            new SubCategoryModel { Id = 39, SubCategoryName = "It-brottslingarnas verktyg", SegmentId = 7 },
            new SubCategoryModel { Id = 40, SubCategoryName = "Mirai, Wannacry och fallet D�sseldorf", SegmentId = 7 },
            new SubCategoryModel { Id = 41, SubCategoryName = "De s�rbara molnen", SegmentId = 7 },


            // Category 3 - "Cyberspionage"
            // Subcategories for "Cyberspionage", Segment "Del 1"
            new SubCategoryModel { Id = 42, SubCategoryName = "Allm�nt om cyberspionage", SegmentId = 8 },
            new SubCategoryModel { Id = 43, SubCategoryName = "Kryptering", SegmentId = 8 },
            new SubCategoryModel { Id = 44, SubCategoryName = "Insiderhot", SegmentId = 8 },
            new SubCategoryModel { Id = 45, SubCategoryName = "Mjukvarus�rbarheter i cyberspionageattacker.", SegmentId = 8 },
            new SubCategoryModel { Id = 46, SubCategoryName = "Metoder f�r cyberspionage", SegmentId = 8 },
            new SubCategoryModel { Id = 47, SubCategoryName = "S�kerhetsskyddslagen", SegmentId = 8 },
            new SubCategoryModel { Id = 48, SubCategoryName = "Cyberspionagets akt�rer", SegmentId = 8 },

            // Subcategories for "Cyberspionage", Segment "Del 2"
            new SubCategoryModel { Id = 49, SubCategoryName = "V�rvningsf�rs�k", SegmentId = 9 },
            new SubCategoryModel { Id = 50, SubCategoryName = "Aff�rsspionage", SegmentId = 9 },
            new SubCategoryModel { Id = 51, SubCategoryName = "P�verkanskampanjer", SegmentId = 9 },

            // Subcategories for "Cyberspionage", Segment "Del 3"
            new SubCategoryModel { Id = 52, SubCategoryName = "Svensk underr�ttelsetj�nst och cyberf�rsvar", SegmentId = 10 },
            new SubCategoryModel { Id = 53, SubCategoryName = "Signalspaning, informationss�kerhet och 5G", SegmentId = 10 },
            new SubCategoryModel { Id = 54, SubCategoryName = "Samverkan mot cyberspionage", SegmentId = 10 }
            );


            builder.Entity<QuestionModel>().HasData(

            // Category - "Att skydda sig mot bedr�gerier"
            // Questions for segment - "Del 1"
            new QuestionModel { Id = 1, Question = "Du f�r ett ov�ntat telefonsamtal fr�n n�gon som p�st�r sig vara fr�n din bank. Personen ber dig bekr�fta ditt kontonummer och l�senord f�r att \"s�kerst�lla din kontos s�kerhet\" efter en p�st�dd s�kerhetsincident. Hur b�r du tolka denna situation?", SubCategoryId = 1 },
            new QuestionModel { Id = 2, Question = "Vad b�r du g�ra omedelbart efter att ha mottagit ett misst�nkt telefonsamtal d�r n�gon fr�gar efter personlig finansiell information?", SubCategoryId = 2 },
            new QuestionModel { Id = 3, Question = "Vilket av f�ljande p�st�enden �r sant ang�ende hur finansiella institutioner kommunicerar med sina kunder?", SubCategoryId = 3 },
            new QuestionModel { Id = 4, Question = "Hur kan du b�st skydda dig mot telefonbedr�gerier?", SubCategoryId = 4 },
            new QuestionModel { Id = 5, Question = "Efter flera m�nader av daglig kommunikation med n�gon du tr�ffade p� en datingsida, b�rjar personen ber�tta om en pl�tslig finansiell kris och ber om din hj�lp genom att �verf�ra pengar. Vad indikerar detta mest sannolikt?", SubCategoryId = 5 },
            new QuestionModel { Id = 6, Question = "Du f�r ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-f�retag som p�st�s ha en revolutionerande ny teknologi, med garantier om exceptionellt h�g avkastning p� mycket kort tid. Hur b�r du f�rh�lla dig till erbjudandet?", SubCategoryId = 6 },
            new QuestionModel { Id = 7, Question = "Efter en online-shoppingrunda m�rker du oidentifierade transaktioner p� ditt kreditkortsutdrag fr�n f�retag du aldrig handlat fr�n. Vad indikerar detta mest sannolikt?", SubCategoryId = 7 },

            // Questions for segment - "Del 2"
            new QuestionModel { Id = 8, Question = "Vilka �r tecknen p� att du kan vara utsatt f�r ett bedr�geri relaterat till hemf�rs�ljning eller hantverkstj�nster?", SubCategoryId = 8 },
            new QuestionModel { Id = 9, Question = "Vilka steg b�r du ta f�r att skydda dig mot identitetsst�ld?", SubCategoryId = 9 },
            new QuestionModel { Id = 10, Question = "Hur b�r du agera om du mottar ett e-postmeddelande som uppmanar dig att uppdatera dina bankuppgifter via en l�nk?", SubCategoryId = 10 },
            new QuestionModel { Id = 11, Question = "Vad �r ett tydligt tecken p� ett online-investeringsbedr�geri?", SubCategoryId = 11 },

            // Questions for segment - "Del 3"
            new QuestionModel { Id = 12, Question = "Hur kan du undvika att falla f�r abonnemangsf�llor?", SubCategoryId = 12 },
            new QuestionModel { Id = 13, Question = "Vad �r det b�sta s�ttet att skydda dig mot ransomware-attacker?", SubCategoryId = 13 },
            new QuestionModel { Id = 14, Question = "Vad visar statistiken om allm�nhetens f�rh�llningss�tt till cybers�kerhet?", SubCategoryId = 14 },


            // Category - "Cybers�kerhet f�r f�retag"
            // Questions for segment - "Del 1"
            new QuestionModel { Id = 15, Question = "Inom f�retaget m�rker man att konfidentiella dokument regelbundet l�cker ut till konkurrenter. Efter en intern granskning uppt�cks det att en anst�lld omedvetet har installerat skadlig programvara genom att klicka p� en l�nk i ett phishing-e-postmeddelande. Vilken �tg�rd b�r prioriteras f�r att f�rhindra framtida incidenter?", SubCategoryId = 15 },
            new QuestionModel { Id = 16, Question = "Vilken �tg�rd �r mest effektiv f�r att s�kerst�lla att anst�llda regelbundet uppdaterar sina l�senord till starkare och mer komplexa versioner?", SubCategoryId = 16 },
            new QuestionModel { Id = 17, Question = "Hur kan f�retaget effektivt minska risken f�r att anst�llda oavsiktligt exponerar f�retagsdata via otrygga Wi-Fi-n�tverk?", SubCategoryId = 17 },
            new QuestionModel { Id = 18, Question = "Vilken �tg�rd b�r ett f�retag ta f�r att skydda sig mot intr�ng via e-postbaserade hot som phishing?", SubCategoryId = 18 },
            new QuestionModel { Id = 19, Question = "Inom f�retaget uppt�ckts det en s�rbarhet i v�r programvara som kunde m�jligg�ra obeh�rig �tkomst till anv�ndardata. F�retaget har inte omedelbart en l�sning. Vilken �r den mest l�mpliga f�rsta �tg�rden?", SubCategoryId = 19 },
            new QuestionModel { Id = 20, Question = "V�rt f�retag blir m�ltavla f�r en DDoS-attack som �verv�ldigar v�ra servers och g�r v�ra tj�nster otillg�ngliga f�r kunder. Vilken typ av akt�r �r mest sannolikt ansvarig f�r denna typ av attack?", SubCategoryId = 20 },
            new QuestionModel { Id = 21, Question = "Med �verg�ngen till distansarbete uppt�cker v�rt f�retag en �kning av s�kerhetsincidenter, inklusive obeh�rig �tkomst till f�retagsdata. Vilken �tg�rd b�r f�retaget vidta f�r att adressera denna nya riskmilj�?", SubCategoryId = 21 },
            new QuestionModel { Id = 22, Question = "H�lsov�rdsmyndigheten uts�tts f�r ett cyberangrepp som krypterar patientdata och kr�ver l�sen f�r att �terst�lla �tkomsten. Vilken typ av angrepp har de sannolikt blivit utsatta f�r?", SubCategoryId = 22 },
            new QuestionModel { Id = 23, Question = "Det globala fraktbolaget Maersk blev offer f�r ett omfattande cyberangrepp som avsev�rt st�rde deras verksamhet v�rlden �ver. Vilken typ av malware var prim�rt ansvarig f�r denna incident?", SubCategoryId = 23 },

            // Questions for segment - "Del 2"
            new QuestionModel { Id = 24, Question = "Vad �r den vanligaste metoden f�r social engineering?", SubCategoryId = 24 },
            new QuestionModel { Id = 25, Question = "Vad �r det mest effektiva s�ttet att hantera n�tfiske?", SubCategoryId = 25 },
            new QuestionModel { Id = 26, Question = "Hur kan man b�st skydda sig mot vishing?", SubCategoryId = 26 },
            new QuestionModel { Id = 27, Question = "Vilket tecken kan tyda p� att ett telefonsamtal �r ett vishing-f�rs�k?", SubCategoryId = 27 },
            new QuestionModel { Id = 28, Question = "Vad b�r man g�ra om man mottar ett e-postmeddelande d�r VD:n verkar be om konfidentiell information?", SubCategoryId = 28 },
            new QuestionModel { Id = 29, Question = "Hur kan man identifiera ett �neangrepp eller presentkortsbluff?", SubCategoryId = 29 },

            // Questions for segment - "Del 3"
            new QuestionModel { Id = 30, Question = "Vad �r skillnaden mellan virus, maskar och trojaner?", SubCategoryId = 30 },
            new QuestionModel { Id = 31, Question = "Hur sker vanligtvis ett dataintr�ng?", SubCategoryId = 31 },
            new QuestionModel { Id = 32, Question = "Vilka �r tecknen p� att ditt n�tverk kan ha blivit komprometterat?", SubCategoryId = 32 },
            new QuestionModel { Id = 33, Question = "Vilka steg b�r tas efter ett uppt�ckt dataintr�ng?", SubCategoryId = 33 },
            new QuestionModel { Id = 34, Question = "Vad b�r man g�ra om man uppt�cker att ens personliga data har blivit hackad?", SubCategoryId = 34 },
            new QuestionModel { Id = 35, Question = "Vilka �r de vanligaste metoderna angripare anv�nder f�r att infiltrera n�tverk?", SubCategoryId = 35 },

            // Questions for segment - "Del 4"
            new QuestionModel { Id = 36, Question = "Vilka �tg�rder b�r vidtas f�r att skydda sig mot utpressningsvirus?", SubCategoryId = 36 },
            new QuestionModel { Id = 37, Question = "Hur kan f�retag f�rebygga attacker mot sina servrar?", SubCategoryId = 37 },
            new QuestionModel { Id = 38, Question = "Vilken typ av cyberangrepp har varit s�rskilt utbredda i de nordiska l�nderna?", SubCategoryId = 38 },
            new QuestionModel { Id = 39, Question = "Vilka verktyg anv�nder IT-brottslingar ofta f�r att genomf�ra sina attacker?", SubCategoryId = 39 },
            new QuestionModel { Id = 40, Question = "Vad har dessa cyberangrepp gemensamt?", SubCategoryId = 40 },
            new QuestionModel { Id = 41, Question = "Hur kan organisationer minska risken f�r s�kerhetshot i molnet?", SubCategoryId = 41 },


            // Category - "Cyberspionage"
            // Questions for segment - "Del 1"
            new QuestionModel { Id = 42, Question = "Regeringen uppt�cker att k�nslig politisk kommunikation har l�ckt och misst�nker elektronisk �vervakning. Vilket fenomen beskriver b�st denna situation?", SubCategoryId = 42 },
            new QuestionModel { Id = 43, Question = "Vilken f�rsvarsstrategi �r mest effektiv mot cyberspionage som riktar sig mot k�nslig kommunikation?", SubCategoryId = 43 },
            new QuestionModel { Id = 44, Question = "Hur kan organisationer b�st uppt�cka och motverka insiderhot som bidrar till cyberspionage?", SubCategoryId = 44 },
            new QuestionModel { Id = 45, Question = "Vilken �tg�rd �r viktigast f�r att skydda sig mot cyberspionage genom utnyttjande av mjukvarus�rbarheter?", SubCategoryId = 45 },
            new QuestionModel { Id = 46, Question = "Regeringen blir varse om en sofistikerad skadeprogramskampanj som utnyttjar Zero-day s�rbarheter f�r att infiltrera deras n�tverk och stj�la oerh�rt viktig data. Vilken metod f�r cyberspionage anv�nds sannolikt h�r?", SubCategoryId = 46 },
            new QuestionModel { Id = 47, Question = "Regeringen i Sverige �kar sitt interna s�kerhetsprotokoll f�r att skydda sig mot utl�ndska underr�ttelsetj�nsters infiltration. Vilken lagstiftning ger ramverket f�r detta skydd?", SubCategoryId = 47 },
            new QuestionModel { Id = 48, Question = "Lunds universitet uppt�cker att forskningsdata om ny teknologi har stulits. Unders�kningar tyder p� en v�lorganiserad grupp med kopplingar till en utl�ndsk stat. Vilken typ av akt�r ligger sannolikt bakom detta?", SubCategoryId = 48 },

            // Questions for segment - "Del 2"
            new QuestionModel { Id = 49, Question = "Hur kan organisationer identifiera och skydda sig mot v�rvningsf�rs�k av utl�ndska underr�ttelsetj�nster?", SubCategoryId = 49 },
            new QuestionModel { Id = 50, Question = "Vilka tecken kan tyda p� att ett f�retag �r m�let f�r aff�rsspionage?", SubCategoryId = 50 },
            new QuestionModel { Id = 51, Question = "Hur kan samh�llen och organisationer f�rsvara sig mot informationsp�verkanskampanjer?", SubCategoryId = 51 },

            // Questions for segment - "Del 3"
            new QuestionModel { Id = 52, Question = "Hur arbetar den svenska underr�ttelsetj�nsten med att st�rka landets cyberf�rsvar? ", SubCategoryId = 52 },
            new QuestionModel { Id = 53, Question = "Vilken roll spelar signalspaning och informationss�kerhet i utvecklingen och implementeringen av 5G-teknologi?", SubCategoryId = 53 },
            new QuestionModel { Id = 54, Question = "Hur kan l�nder effektivt samverka f�r att bek�mpa cyberspionage?", SubCategoryId = 54 }
            );


            // Prompts for each question
            builder.Entity<PromptModel>().HasData(

            // Question 1
            new PromptModel
            {
                Id = 1,
                Prompt = "Ett legitimt f�rs�k fr�n banken att skydda ditt konto",
                IsCorrect = false,
                QuestionId = 1,
            },
            new PromptModel
            {
                Id = 2,
                Prompt = "En informationsinsamling f�r en marknadsunders�kning",
                IsCorrect = false,

                QuestionId = 1,
            },
            new PromptModel
            {
                Id = 3,
                Prompt = "Ett potentiellt telefonbedr�geri",
                IsCorrect = true,
                QuestionId = 1,
            },

            // Question 2
            new PromptModel
            {
                Id = 4,
                Prompt = "Ge dem informationen de ber om, f�r s�kerhets skull",
                IsCorrect = false,
                QuestionId = 2
            },
            new PromptModel
            {
                Id = 5,
                Prompt = "Avsluta samtalet och kontakta din bank direkt via ett officiellt nummer du vet �r korrekt",
                IsCorrect = true,
                QuestionId = 2
            },
            new PromptModel
            {
                Id = 6,
                Prompt = "V�nta p� att de ska ringa tillbaka f�r att bekr�fta deras legitimitet",
                IsCorrect = false,

                QuestionId = 2
            },

            // Question 3
            new PromptModel
            {
                Id = 7,
                Prompt = "Banker skickar ofta e-postmeddelanden som ber kunder att direkt ange l�senord och kontonummer f�r verifiering.",
                IsCorrect = false,
                QuestionId = 3
            },
            new PromptModel
            {
                Id = 8,
                Prompt = "Banker ringer regelbundet sina kunder f�r att be dem upprepa sina kontouppgifter f�r s�kerhetsuppdateringar.",
                IsCorrect = false,
                QuestionId = 3
            },
            new PromptModel
            {
                Id = 9,
                Prompt = "Banker och finansiella institutioner kommer aldrig att be dig om ditt l�senord eller kontonummer via telefon eller e-post.",
                IsCorrect = true,
                QuestionId = 3
            },

            // Question 4
            new PromptModel
            {
                Id = 10,
                Prompt = "Installera en app som blockerar misst�nkta samtal.",
                IsCorrect = false,
                QuestionId = 4
            },
            new PromptModel
            {
                Id = 11,
                Prompt = "Aldrig svara p� samtal fr�n ok�nda nummer.",
                IsCorrect = false,
                QuestionId = 4
            },
            new PromptModel
            {
                Id = 12,
                Prompt = "Uppr�tta starka s�kerhetsfr�gor med din bank som kr�vs f�r att identifiera dig �ver telefon.",
                IsCorrect = true,
                QuestionId = 4
            },

            // Question 5
            new PromptModel
            {
                Id = 13,
                Prompt = "En legitim beg�ran om hj�lp fr�n en person i n�d.",
                IsCorrect = false,
                QuestionId = 5
            },
            new PromptModel
            {
                Id = 14,
                Prompt = "Ett romansbedr�geri.",
                IsCorrect = true,
                QuestionId = 5
            },
            new PromptModel
            {
                Id = 15,
                Prompt = "En tillf�llig ekonomisk sv�righet.",
                IsCorrect = false,
                QuestionId = 5
            },

            // Question 6
            new PromptModel
            {
                Id = 16,
                Prompt = "Genomf�ra omedelbar investering f�r att inte missa m�jligheten.",
                IsCorrect = false,
                QuestionId = 6
            },
            new PromptModel
            {
                Id = 17,
                Prompt = "Investeringsbedr�geri.",
                IsCorrect = true,
                QuestionId = 6
            },
            new PromptModel
            {
                Id = 18,
                Prompt = "Beg�ra mer information f�r att utf�ra en noggrann ?due diligence?.",
                IsCorrect = false,
                QuestionId = 6
            },

            // Question 7
            new PromptModel
            {
                Id = 19,
                Prompt = "Ett misstag av kreditkortsf�retaget",
                IsCorrect = false,
                QuestionId = 7
            },
            new PromptModel
            {
                Id = 20,
                Prompt = "Kreditkortsbedr�geri",
                IsCorrect = true,
                QuestionId = 7
            },
            new PromptModel
            {
                Id = 21,
                Prompt = "Obeh�riga k�p av en familjemedlem",
                IsCorrect = false,
                QuestionId = 7
            },

            // Question 8
            new PromptModel
            {
                Id = 22,
                Prompt = "S�ljaren kr�ver omedelbar betalning eller en stor f�rskottsbetalning.",
                IsCorrect = false,

                QuestionId = 8
            },
            new PromptModel
            {
                Id = 23,
                Prompt = "S�ljaren erbjuder en \"eng�ngserbjudande\" som bara g�ller under bes�ket.",
                IsCorrect = false,

                QuestionId = 8
            },
            new PromptModel
            {
                Id = 24,
                Prompt = "Alla svaren.",
                IsCorrect = true,

                QuestionId = 8
            },

            // Question 9
            new PromptModel
            {
                Id = 25,
                Prompt = "Dela regelbundet personlig information p� sociala medier",
                IsCorrect = false,

                QuestionId = 9
            },
            new PromptModel
            {
                Id = 26,
                Prompt = "�vervaka dina kontoutdrag och anv�nd starka, unika l�senord",
                IsCorrect = true,

                QuestionId = 9
            },
            new PromptModel
            {
                Id = 27,
                Prompt = "Anv�nda offentligt Wi-Fi f�r alla dina finansiella transaktioner",
                IsCorrect = false,

                QuestionId = 9
            },

            // Question 10
            new PromptModel
            {
                Id = 28,
                Prompt = "Klicka p� l�nken och f�lj instruktionerna",
                IsCorrect = false,

                QuestionId = 10
            },
            new PromptModel
            {
                Id = 29,
                Prompt = "Ignorera e-postmeddelandet och radera det",
                IsCorrect = false,

                QuestionId = 10
            },
            new PromptModel
            {
                Id = 30,
                Prompt = "Kontakta banken direkt via officiella kommunikationskanaler f�r att verifiera f�rfr�gan",
                IsCorrect = true,

                QuestionId = 10
            },

            // Question 11
            new PromptModel
            {
                Id = 31,
                Prompt = "Garanterad h�g avkastning med liten eller ingen risk",
                IsCorrect = true,

                QuestionId = 11
            },
            new PromptModel
            {
                Id = 32,
                Prompt = "Krav p� omedelbar investering f�r att s�kra platsen",
                IsCorrect = false,

                QuestionId = 11
            },
            new PromptModel
            {
                Id = 33,
                Prompt = "Erbjudanden som endast baseras p� verkliga marknadsf�rh�llanden",
                IsCorrect = false,

                QuestionId = 11
            },

            // Question 12
            new PromptModel
            {
                Id = 34,
                Prompt = "Registrera dig f�r alla erbjudanden du f�r via e-post",
                IsCorrect = false,

                QuestionId = 12
            },
            new PromptModel
            {
                Id = 35,
                Prompt = "L�s noggrant igenom avtal och villkor innan du tecknar n�got abonnemang",
                IsCorrect = true,

                QuestionId = 12
            },
            new PromptModel
            {
                Id = 36,
                Prompt = "Ge ut ditt kreditkortnummer till alla webbplatser som erbjuder gratis pr�voperioder",
                IsCorrect = false,

                QuestionId = 12
            },

            // Question 13
            new PromptModel
            {
                Id = 37,
                Prompt = "�ppna bilagor i e-postmeddelanden fr�n ok�nda avs�ndare",
                IsCorrect = false,

                QuestionId = 13
            },
            new PromptModel
            {
                Id = 38,
                Prompt = "S�kerhetskopiera dina data regelbundet och h�lla ditt antivirusprogram uppdaterat",
                IsCorrect = true,

                QuestionId = 13
            },
            new PromptModel
            {
                Id = 39,
                Prompt = "Betala l�sen direkt f�r att f� tillbaka dina filer",
                IsCorrect = false,

                QuestionId = 13
            },

            // Question 14
            new PromptModel
            {
                Id = 40,
                Prompt = "Majoriteten av personer �r inte medvetna om grundl�ggande cybers�kerhetsprinciper",
                IsCorrect = true,

                QuestionId = 14
            },
            new PromptModel
            {
                Id = 41,
                Prompt = "De flesta anv�nder komplexa l�senord och �ndrar dem regelbundet",
                IsCorrect = false,

                QuestionId = 14
            },
            new PromptModel
            {
                Id = 42,
                Prompt = "En stor del av befolkningen k�nner sig helt s�kra n�r de surfar p� internet",
                IsCorrect = false,

                QuestionId = 14
            },

            // Question 15
            new PromptModel
            {
                Id = 43,
                Prompt = "Utbildning i digital s�kerhet f�r alla anst�llda",
                IsCorrect = true,

                QuestionId = 15
            },
            new PromptModel
            {
                Id = 44,
                Prompt = "Installera en starkare brandv�gg",
                IsCorrect = false,

                QuestionId = 15
            },
            new PromptModel
            {
                Id = 45,
                Prompt = "Byta ut all IT-utrustning",
                IsCorrect = false,

                QuestionId = 15
            },

            // Question 16
            new PromptModel
            {
                Id = 46,
                Prompt = "Manuellt kontrollera varje anst�llds l�senord en g�ng per �r",
                IsCorrect = false,

                QuestionId = 16
            },
            new PromptModel
            {
                Id = 47,
                Prompt = "Implementera en policy f�r l�senordskomplexitet som kr�ver automatiska l�senords�ndringar var 90:e dag",
                IsCorrect = true,

                QuestionId = 16
            },
            new PromptModel
            {
                Id = 48,
                Prompt = "Uppmana anst�llda att v�lja l�ttih�gda l�senord f�r att undvika att skriva ner dem",
                IsCorrect = false,

                QuestionId = 16
            },

            // Question 17
            new PromptModel
            {
                Id = 49,
                Prompt = "F�rbjuda anv�ndning av offentliga Wi-Fi-n�tverk helt och h�llet",
                IsCorrect = false,

                QuestionId = 17
            },
            new PromptModel
            {
                Id = 50,
                Prompt = "Utrusta alla anst�lldas enheter med VPN (Virtual Private Network)-tj�nster",
                IsCorrect = true,

                QuestionId = 17
            },
            new PromptModel
            {
                Id = 51,
                Prompt = "Endast till�ta anst�llda att arbeta offline n�r de inte �r p� kontoret",
                IsCorrect = false,

                QuestionId = 17
            },

            // Question 18
            new PromptModel
            {
                Id = 52,
                Prompt = "Blockera all inkommande e-post fr�n externa k�llor",
                IsCorrect = false,

                QuestionId = 18
            },
            new PromptModel
            {
                Id = 53,
                Prompt = "Installera och uppdatera regelbundet e-posts�kerhetsl�sningar som filtrerar bort skadlig programvara och misst�nkta l�nkar",
                IsCorrect = true,

                QuestionId = 18
            },
            new PromptModel
            {
                Id = 54,
                Prompt = "L�ta anst�llda anv�nda personliga e-postkonton f�r arbete f�r att minska risken f�r f�retagets e-postservers s�kerhet",
                IsCorrect = false,

                QuestionId = 18
            },

            // Question 19
            new PromptModel
            {
                Id = 55,
                Prompt = "Informera alla anv�ndare om s�rbarheten och rekommendera tempor�ra skydds�tg�rder",
                IsCorrect = true,

                QuestionId = 19
            },
            new PromptModel
            {
                Id = 56,
                Prompt = "Ignorera problemet tills en patch kan utvecklas",
                IsCorrect = false,

                QuestionId = 19
            },
            new PromptModel
            {
                Id = 57,
                Prompt = "St�nga ner tj�nsten tillf�lligt",
                IsCorrect = false,

                QuestionId = 19
            },

            // Question 20
            new PromptModel
            {
                Id = 58,
                Prompt = "En enskild hackare med ett personligt vendetta",
                IsCorrect = false,

                QuestionId = 20
            },
            new PromptModel
            {
                Id = 59,
                Prompt = "En konkurrerande f�retagsentitet",
                IsCorrect = false,

                QuestionId = 20
            },
            new PromptModel
            {
                Id = 60,
                Prompt = "Organiserade cyberbrottsliga grupper",
                IsCorrect = true,

                QuestionId = 20
            },

            // Question 21
            new PromptModel
            {
                Id = 61,
                Prompt = "�terg� till kontorsarbete",
                IsCorrect = false,

                QuestionId = 21
            },
            new PromptModel
            {
                Id = 62,
                Prompt = "Inf�ra striktare l�senordspolicyer och tv�faktorsautentisering f�r fj�rr�tkomst",
                IsCorrect = true,

                QuestionId = 21
            },
            new PromptModel
            {
                Id = 63,
                Prompt = "F�rbjuda anv�ndning av personliga enheter f�r arbete",
                IsCorrect = false,

                QuestionId = 21
            },

            // Question 22
            new PromptModel
            {
                Id = 64,
                Prompt = "Phishing",
                IsCorrect = false,

                QuestionId = 22
            },
            new PromptModel
            {
                Id = 65,
                Prompt = "Ransomware",
                IsCorrect = true,

                QuestionId = 22
            },
            new PromptModel
            {
                Id = 66,
                Prompt = "Spyware",
                IsCorrect = false,

                QuestionId = 22
            },

            // Question 23
            new PromptModel
            {
                Id = 67,
                Prompt = "Spyware",
                IsCorrect = false,

                QuestionId = 23
            },
            new PromptModel
            {
                Id = 68,
                Prompt = "Ransomware",
                IsCorrect = true,

                QuestionId = 23
            },
            new PromptModel
            {
                Id = 69,
                Prompt = "Adware",
                IsCorrect = false,

                QuestionId = 23
            },

            // Question 24
            new PromptModel
            {
                Id = 70,
                Prompt = "Utnyttjande av tekniska s�kerhetsh�l",
                IsCorrect = false,

                QuestionId = 24
            },
            new PromptModel
            {
                Id = 71,
                Prompt = "Personlig manipulation f�r att f� obeh�rig �tkomst till information",
                IsCorrect = true,

                QuestionId = 24
            },
            new PromptModel
            {
                Id = 72,
                Prompt = "�ppna d�rrar med hj�lp av fysisk kraft",
                IsCorrect = false,

                QuestionId = 24
            },

            // Question 25
            new PromptModel
            {
                Id = 73,
                Prompt = "Svara p� alla misst�nkta e-postmeddelanden f�r att bekr�fta deras �kthet",
                IsCorrect = false,

                QuestionId = 25
            },
            new PromptModel
            {
                Id = 74,
                Prompt = "Ignorera och radera misst�nkta e-postmeddelanden utan att klicka p� l�nkar",
                IsCorrect = true,

                QuestionId = 25
            },
            new PromptModel
            {
                Id = 75,
                Prompt = "�verf�ra alla misst�nkta e-postmeddelanden till kollegor f�r en andra �sikt",
                IsCorrect = false,

                QuestionId = 25
            },

            // Question 26
            new PromptModel
            {
                Id = 76,
                Prompt = "Alltid ge ut personlig information �ver telefon n�r n�gon fr�gar",
                IsCorrect = false,

                QuestionId = 26
            },
            new PromptModel
            {
                Id = 77,
                Prompt = "Kontrollera identiteten hos personen som ringer genom att ringa tillbaka till ett officiellt nummer",
                IsCorrect = true,

                QuestionId = 26
            },
            new PromptModel
            {
                Id = 78,
                Prompt = "Ignorera alla telefonsamtal fr�n ok�nda nummer",
                IsCorrect = false,

                QuestionId = 26
            },

            // Question 27
            new PromptModel
            {
                Id = 79,
                Prompt = "Samtalet kommer fr�n ett nummer som du k�nner igen",
                IsCorrect = false,

                QuestionId = 27
            },
            new PromptModel
            {
                Id = 80,
                Prompt = "Den som ringer erbjuder en tidsbegr�nsad aff�r som verkar f�r bra f�r att vara sann",
                IsCorrect = true,

                QuestionId = 27
            },
            new PromptModel
            {
                Id = 81,
                Prompt = "Den som ringer beg�r inga personliga uppgifter",
                IsCorrect = false,

                QuestionId = 27
            },

            // Question 28
            new PromptModel
            {
                Id = 82,
                Prompt = "Omedelbart svara och tillhandah�lla beg�rd information",
                IsCorrect = false,

                QuestionId = 28
            },
            new PromptModel
            {
                Id = 83,
                Prompt = "Verifiera beg�ran direkt med VD:n genom en separat kommunikationskanal",
                IsCorrect = true,

                QuestionId = 28
            },
            new PromptModel
            {
                Id = 84,
                Prompt = "Skicka informationen till hela f�retaget f�r att dubbelkolla autenticiteten",
                IsCorrect = false,

                QuestionId = 28
            },

            // Question 29
            new PromptModel
            {
                Id = 85,
                Prompt = "N�r du f�r ett erbjudande som kr�ver att du k�per och skickar presentkort som betalning",
                IsCorrect = true,

                QuestionId = 29
            },
            new PromptModel
            {
                Id = 86,
                Prompt = "N�r en kollega personligen ber dig k�pa ett presentkort f�r dem",
                IsCorrect = false,

                QuestionId = 29
            },
            new PromptModel
            {
                Id = 87,
                Prompt = "N�r du f�r en rabatt p� presentkort som endast kan k�pas genom direktl�nkar i e-post",
                IsCorrect = false,

                QuestionId = 29
            },

            // Question 30
            new PromptModel
            {
                Id = 88,
                Prompt = "Virus beh�ver ett v�rdprogram f�r att spridas, maskar sprider sig sj�lvst�ndigt, och trojaner d�ljer sig som legitima program",
                IsCorrect = true,

                QuestionId = 30
            },
            new PromptModel
            {
                Id = 89,
                Prompt = "Virus och maskar �r skadliga, men trojaner �r ofarliga",
                IsCorrect = false,

                QuestionId = 30
            },
            new PromptModel
            {
                Id = 90,
                Prompt = "Virus sprider sig via e-post, maskar via n�tverk och trojaner kan inte sprida sig alls",
                IsCorrect = false,

                QuestionId = 30
            },

            // Question 31
            new PromptModel
            {
                Id = 91,
                Prompt = "Genom fysisk �tkomst till f�retagets servrar",
                IsCorrect = false,

                QuestionId = 31
            },
            new PromptModel
            {
                Id = 92,
                Prompt = "Anv�ndning av avancerad kryptering f�r att skydda data",
                IsCorrect = false,

                QuestionId = 31
            },
            new PromptModel
            {
                Id = 93,
                Prompt = "Utnyttjande av s�kerhetsh�l i programvara eller system",
                IsCorrect = true,

                QuestionId = 31
            },

            // Question 32
            new PromptModel
            {
                Id = 94,
                Prompt = "�kad n�tverkstrafik under udda tider",
                IsCorrect = true,

                QuestionId = 32
            },
            new PromptModel
            {
                Id = 95,
                Prompt = "Alla filer �r krypterade och o�tkomliga",
                IsCorrect = false,

                QuestionId = 32
            },
            new PromptModel
            {
                Id = 96,
                Prompt = "Snabbare internetanslutning �n vanligt",
                IsCorrect = false,

                QuestionId = 32
            },

            // Question 33
            new PromptModel
            {
                Id = 97,
                Prompt = "Informera alla ber�rda parter och genomf�r en grundlig s�kerhetsrevision",
                IsCorrect = true,

                QuestionId = 33
            },
            new PromptModel
            {
                Id = 98,
                Prompt = "Ignorera problemet och hoppas att det g�r �ver av sig sj�lvt",
                IsCorrect = false,

                QuestionId = 33
            },
            new PromptModel
            {
                Id = 99,
                Prompt = "�ka antalet l�senord anv�ndaren m�ste komma ih�g",
                IsCorrect = false,

                QuestionId = 33
            },

            // Question 34
            new PromptModel
            {
                Id = 100,
                Prompt = "Byt omedelbart l�senord och aktivera tv�faktorsautentisering d�r det �r m�jligt",
                IsCorrect = true,

                QuestionId = 34
            },
            new PromptModel
            {
                Id = 101,
                Prompt = "Publicera informationen p� sociala medier f�r att varna andra",
                IsCorrect = false,

                QuestionId = 34
            },
            new PromptModel
            {
                Id = 102,
                Prompt = "Anv�nd samma l�senord igen f�r att se om hackaren ger upp",
                IsCorrect = false,

                QuestionId = 34
            },

            // Question 35
            new PromptModel
            {
                Id = 103,
                Prompt = "Social engineering, utnyttjande av programvarus�rbarheter och phishing",
                IsCorrect = true,

                QuestionId = 35
            },
            new PromptModel
            {
                Id = 104,
                Prompt = "Annonsering av falska jobberbjudanden",
                IsCorrect = false,

                QuestionId = 35
            },
            new PromptModel
            {
                Id = 105,
                Prompt = "Skicka brev med skadlig programvara till f�retagets adress",
                IsCorrect = false,

                QuestionId = 35
            },

            // Question 36
            new PromptModel
            {
                Id = 106,
                Prompt = "Betala l�sen direkt till angriparen f�r att �terf� tillg�ng till filerna",
                IsCorrect = false,

                QuestionId = 36
            },
            new PromptModel
            {
                Id = 107,
                Prompt = "Regelbunden s�kerhetskopiering av viktig data och anv�ndning av s�kerhetsprogramvara",
                IsCorrect = true,

                QuestionId = 36
            },
            new PromptModel
            {
                Id = 108,
                Prompt = "�ppna alla e-postbilagor f�r att kontrollera om de inneh�ller utpressningsvirus",
                IsCorrect = false,

                QuestionId = 36
            },

            // Question 37
            new PromptModel
            {
                Id = 109,
                Prompt = "L�mna servrarna ouppdaterade f�r att undvika kompatibilitetsproblem",
                IsCorrect = false,

                QuestionId = 37
            },
            new PromptModel
            {
                Id = 110,
                Prompt = "Anv�nd starka l�senord och regelbundna s�kerhetsuppdateringar",
                IsCorrect = true,

                QuestionId = 37
            },
            new PromptModel
            {
                Id = 111,
                Prompt = "Inaktivera brandv�ggar f�r att f�rb�ttra n�tverksprestandan",
                IsCorrect = false,

                QuestionId = 37
            },

            // Question 38
            new PromptModel
            {
                Id = 112,
                Prompt = "Fysiska intr�ng i datacenter",
                IsCorrect = false,

                QuestionId = 38
            },
            new PromptModel
            {
                Id = 113,
                Prompt = "Sociala medier-bedr�gerier",
                IsCorrect = false,

                QuestionId = 38
            },
            new PromptModel
            {
                Id = 114,
                Prompt = "Ransomware och phishing-kampanjer",
                IsCorrect = true,

                QuestionId = 38
            },

            // Question 39
            new PromptModel
            {
                Id = 115,
                Prompt = "Avancerade krypteringsalgoritmer f�r att skydda deras egna data",
                IsCorrect = false,

                QuestionId = 39
            },
            new PromptModel
            {
                Id = 116,
                Prompt = "Malware, keyloggers och botnets f�r att infiltrera och kontrollera system",
                IsCorrect = true,

                QuestionId = 39
            },
            new PromptModel
            {
                Id = 117,
                Prompt = "Offentliga Wi-Fi-n�tverk f�r att anonymt skicka e-post",
                IsCorrect = false,

                QuestionId = 39
            },

            // Question 40
            new PromptModel
            {
                Id = 121,
                Prompt = "De orsakades av fysiska s�kerhetsbrister",
                IsCorrect = false,

                QuestionId = 40
            },
            new PromptModel
            {
                Id = 122,
                Prompt = "De utnyttjade s�rbarheter i outdaterad programvara",
                IsCorrect = true,

                QuestionId = 40
            },
            new PromptModel
            {
                Id = 123,
                Prompt = "De var riktade mot specifika individer",
                IsCorrect = false,

                QuestionId = 40
            },

            // Question 41
            new PromptModel
            {
                Id = 124,
                Prompt = "Undvika anv�ndning av molntj�nster helt och h�llet",
                IsCorrect = false,

                QuestionId = 41
            },
            new PromptModel
            {
                Id = 125,
                Prompt = "Anv�nda flerfaktorsautentisering och strikt �tkomstkontroll",
                IsCorrect = true,

                QuestionId = 41
            },
            new PromptModel
            {
                Id = 126,
                Prompt = "Lagra all k�nslig information lokalt p� os�krade enheter",
                IsCorrect = false,

                QuestionId = 41
            },

            // Question 42
            new PromptModel
            {
                Id = 127,
                Prompt = "Cyberkriminalitet",
                IsCorrect = false,

                QuestionId = 42
            },
            new PromptModel
            {
                Id = 128,
                Prompt = "Cyberspionage",
                IsCorrect = true,

                QuestionId = 42
            },
            new PromptModel
            {
                Id = 129,
                Prompt = "Cyberterrorism",
                IsCorrect = false,

                QuestionId = 42
            },

            // Question 43
            new PromptModel
            {
                Id = 130,
                Prompt = "�ka anv�ndningen av kryptering f�r all intern och extern kommunikation",
                IsCorrect = true,

                QuestionId = 43
            },
            new PromptModel
            {
                Id = 131,
                Prompt = "F�rbjuda all anv�ndning av e-post och �terg� till fysisk korrespondens",
                IsCorrect = false,

                QuestionId = 43
            },
            new PromptModel
            {
                Id = 132,
                Prompt = "Installera antivirusprogram p� alla datorer",
                IsCorrect = false,

                QuestionId = 43
            },

            // Question 44
            new PromptModel
            {
                Id = 133,
                Prompt = "Genomf�ra strikta bakgrundskontroller av alla anst�llda",
                IsCorrect = false,

                QuestionId = 44
            },
            new PromptModel
            {
                Id = 134,
                Prompt = "Implementera ett omfattande program f�r beteendeanalys och anomalidetektering",
                IsCorrect = true,

                QuestionId = 44
            },
            new PromptModel
            {
                Id = 135,
                Prompt = "Begr�nsa internetanv�ndningen p� arbetsplatsen till arbetsrelaterade aktiviteter",
                IsCorrect = false,

                QuestionId = 44
            },

            // Question 45
            new PromptModel
            {
                Id = 136,
                Prompt = "Genomf�ra regelbundna medvetenhetstr�ningar f�r alla anst�llda om cybers�kerhet",
                IsCorrect = false,

                QuestionId = 45
            },
            new PromptModel
            {
                Id = 137,
                Prompt = "H�lla all mjukvara och operativsystem uppdaterade med de senaste s�kerhetspatcharna",
                IsCorrect = true,

                QuestionId = 45
            },
            new PromptModel
            {
                Id = 138,
                Prompt = "Endast anv�nda egenutvecklad mjukvara f�r alla verksamhetsprocesser",
                IsCorrect = false,

                QuestionId = 45
            },

            // Question 46
            new PromptModel
            {
                Id = 139,
                Prompt = "Social ingenj�rskonst",
                IsCorrect = false,

                QuestionId = 46
            },
            new PromptModel
            {
                Id = 140,
                Prompt = "Mass�vervakning",
                IsCorrect = false,

                QuestionId = 46
            },
            new PromptModel
            {
                Id = 141,
                Prompt = "Riktade cyberattacker",
                IsCorrect = true,

                QuestionId = 46
            },

            // Question 47
            new PromptModel
            {
                Id = 142,
                Prompt = "GDPR",
                IsCorrect = false,

                QuestionId = 47
            },
            new PromptModel
            {
                Id = 143,
                Prompt = "S�kerhetsskyddslagen",
                IsCorrect = true,

                QuestionId = 47
            },
            new PromptModel
            {
                Id = 144,
                Prompt = "IT-s�kerhetslagen",
                IsCorrect = false,

                QuestionId = 47
            },

            // Question 48
            new PromptModel
            {
                Id = 145,
                Prompt = "Oberoende hackare",
                IsCorrect = false,

                QuestionId = 48
            },
            new PromptModel
            {
                Id = 146,
                Prompt = "Aktivistgrupper",
                IsCorrect = false,

                QuestionId = 48
            },
            new PromptModel
            {
                Id = 147,
                Prompt = "Statssponsrade hackers",
                IsCorrect = true,

                QuestionId = 48
            },

            // Question 49
            new PromptModel
            {
                Id = 148,
                Prompt = "Genom att ignorera all kontakt fr�n utl�ndska entiteter",
                IsCorrect = false,

                QuestionId = 49
            },
            new PromptModel
            {
                Id = 149,
                Prompt = "Uppr�tta starka interna s�kerhetsprotokoll och utbildning i medvetenhet om spionage",
                IsCorrect = true,

                QuestionId = 49
            },
            new PromptModel
            {
                Id = 150,
                Prompt = "Anv�nda endast krypterad kommunikation f�r alla aff�rstransaktioner",
                IsCorrect = false,

                QuestionId = 49
            },

            // Question 50
            new PromptModel
            {
                Id = 151,
                Prompt = "Pl�tslig �kning av n�tverkstrafik och ovanliga systemloggar",
                IsCorrect = true,

                QuestionId = 50
            },
            new PromptModel
            {
                Id = 152,
                Prompt = "F�rlust av anst�llda till konkurrerande f�retag",
                IsCorrect = false,

                QuestionId = 50
            },
            new PromptModel
            {
                Id = 153,
                Prompt = "�kad f�rs�ljning och marknadsandelar",
                IsCorrect = false,

                QuestionId = 50
            },

            // Question 51
            new PromptModel
            {
                Id = 154,
                Prompt = "Genom att helt undvika sociala medier",
                IsCorrect = false,

                QuestionId = 51
            },
            new PromptModel
            {
                Id = 155,
                Prompt = "St�rka k�llkritik och sprida medvetenhet om falska nyheter",
                IsCorrect = true,

                QuestionId = 51
            },
            new PromptModel
            {
                Id = 156,
                Prompt = "Endast till�ta godk�nda nyhetsk�llor",
                IsCorrect = false,

                QuestionId = 51
            },

            // Question 52
            new PromptModel
            {
                Id = 157,
                Prompt = "Genom offensiva cyberoperationer mot andra l�nder",
                IsCorrect = false,

                QuestionId = 52
            },
            new PromptModel
            {
                Id = 158,
                Prompt = "Samarbeta nationellt och internationellt f�r informationsutbyte och f�rb�ttring av cybers�kerhet",
                IsCorrect = true,

                QuestionId = 52
            },
            new PromptModel
            {
                Id = 159,
                Prompt = "Fokusera endast p� fysisk s�kerhet",
                IsCorrect = false,

                QuestionId = 52
            },

            // Question 53
            new PromptModel
            {
                Id = 160,
                Prompt = "Ingen, eftersom 5G-teknologi endast ber�r mobiln�tverksoperat�rer",
                IsCorrect = false,

                QuestionId = 53
            },
            new PromptModel
            {
                Id = 161,
                Prompt = "En kritisk roll i att s�kerst�lla att 5G-n�tverk �r s�kra fr�n cyberhot och spioneri",
                IsCorrect = true,

                QuestionId = 53
            },
            new PromptModel
            {
                Id = 162,
                Prompt = "Enbart fokuserad p� priss�ttning och tillg�nglighet av tj�nster",
                IsCorrect = false,

                QuestionId = 53
            },

            // Question 54
            new PromptModel
            {
                Id = 166,
                Prompt = "Genom att isolera sig och endast fokusera p� intern cybers�kerhet",
                IsCorrect = false,

                QuestionId = 54
            },
            new PromptModel
            {
                Id = 167,
                Prompt = "Internationellt informationsutbyte och gemensamma insatser f�r cybers�kerhet",
                IsCorrect = true,

                QuestionId = 54
            },
            new PromptModel
            {
                Id = 168,
                Prompt = "Begr�nsa anv�ndningen av internet globalt",
                IsCorrect = false,

                QuestionId = 54
            });
        }
    }
}



