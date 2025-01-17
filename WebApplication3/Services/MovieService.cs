﻿using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models;

public class MovieService
{
    private static List<Movie> movies = new List<Movie>
    {
        new Movie {Title = "Incepcja", ImageUrl = "/images/inception.jpg", Description = "Historia Dominicka Cobba, mistrza złodziei, który potrafi kraść sekrety z umysłów ludzi poprzez ich sny. Misja, którą podejmuje, może zmienić jego życie na zawsze." },
        new Movie {Title = "Matrix", ImageUrl = "/images/matrix.jpg", Description = "Neo, młody programista komputerowy, odkrywa, że rzeczywistość, którą zna, jest symulacją kontrolowaną przez maszyny. Wkracza w świat rebeliantów walczących o wolność ludzkości." },
        new Movie {Title = "Interstellar", ImageUrl = "/images/interstellar.jpg", Description = "Grupa astronautów wyrusza w podróż przez tunel czasoprzestrzenny, aby znaleźć nowy dom dla ludzkości na odległej planecie, gdy Ziemia staje się niezamieszkiwalna." },
        new Movie {Title = "Mroczny rycerz", ImageUrl = "/images/dark_knight.jpg", Description = "Batman staje w obliczu swojego największego przeciwnika - Jokera, który sieje chaos w Gotham City, zmuszając bohatera do podjęcia trudnych decyzji." },
        new Movie {Title = "Forrest Gump", ImageUrl = "/images/forrest_gump.jpg", Description = "Historia prostodusznego mężczyzny, który staje się świadkiem kluczowych wydarzeń XX wieku, nie zdając sobie sprawy z ich znaczenia." },
        new Movie {Title = "Skazani na Shawshank", ImageUrl = "/images/shawshank.jpg", Description = "Andy Dufresne, skazany na dożywocie za morderstwo, którego nie popełnił, odkrywa wartość przyjaźni i nadziei za murami więzienia." },
        new Movie {Title= "Pulp Fiction", ImageUrl = "/images/pulp_fiction.jpg", Description = "Splątane historie gangstera, jego żony, boksera i dwóch drobnych przestępców tworzą surrealistyczny obraz życia w Los Angeles." },
        new Movie {Title = "Ojciec chrzestny", ImageUrl = "/images/godfather.jpg", Description = "Epicka saga rodziny mafijnej Corleone, ukazująca ich wpływ na świat przestępczy oraz osobiste dramaty jej członków." },
        new Movie {Title = "Władca Pierścieni: Powrót króla", ImageUrl = "/images/lotr_return.jpg", Description = "Frodo i Sam kontynuują swoją podróż do Mordoru, aby zniszczyć pierścień, podczas gdy ich przyjaciele walczą o przetrwanie Śródziemia." },
        new Movie {Title = "Avengers", ImageUrl = "/images/avengers.jpg", Description = "Grupa superbohaterów musi połączyć siły, aby pokonać Lokiego, który planuje przejąć kontrolę nad Ziemią." },
        new Movie {Title = "Titanic", ImageUrl = "/images/titanic.jpg", Description = "Romans pomiędzy Jackiem i Rose na pokładzie słynnego Titanica, który zmierza ku tragicznej katastrofie." },
        new Movie {Title = "Gladiator", ImageUrl = "/images/gladiator.jpg", Description = "Maximus, były generał, zostaje gladiatorem, który walczy o zemstę na cesarzu odpowiedzialnym za śmierć jego rodziny." },
        new Movie {Title = "Gwiezdne wojny: Nowa nadzieja", ImageUrl = "/images/star_wars.jpg", Description = "Luke Skywalker dołącza do Rebelii, aby uratować księżniczkę Leię i pokonać potężne Imperium." },
        new Movie {Title = "Park Jurajski", ImageUrl = "/images/jurassic_park.jpg", Description = "Eksperymentalny park pełen żywych dinozaurów zamienia się w chaos, gdy systemy bezpieczeństwa zawodzą." },
        new Movie {Title = "Król Lew", ImageUrl = "/images/lion_king.jpg", Description = "Młody lew Simba przechodzi trudną drogę, aby odzyskać swoje miejsce jako król sawanny." },
        new Movie {Title = "Podziemny krąg", ImageUrl = "/images/fight_club.jpg", Description = "Anonimowy mężczyzna zakłada tajny klub walki, który szybko wymyka się spod kontroli." },
        new Movie {Title = "Avatar", ImageUrl = "/images/avatar.jpg", Description = "Jake Sully, sparaliżowany żołnierz, odkrywa piękno i niebezpieczeństwo Pandory, wcielając się w awatara." },
        new Movie {Title = "Milczenie owiec", ImageUrl = "/images/silence_lambs.jpg", Description = "Clarice Starling korzysta z pomocy więźnia Hannibala Lectera, aby schwytać seryjnego mordercę." },
        new Movie {Title = "Lista Schindlera", ImageUrl = "/images/schindler.jpg", Description = "Prawdziwa historia Oskara Schindlera, który uratował setki Żydów podczas II wojny światowej." },
        new Movie {Title = "Wilk z Wall Street", ImageUrl = "/images/wolf_wall.jpg", Description = "Ekscentryczny broker Jordan Belfort opowiada o wzlotach i upadkach swojej kariery na Wall Street." },
        new Movie {Title = "Avengers: Koniec gry", ImageUrl = "/images/endgame.jpg", Description = "Ostateczna walka Avengersów z Thanosem, aby przywrócić równowagę we wszechświecie." },
        new Movie {Title = "Toy Story", ImageUrl = "/images/toy_story.jpg", Description = "Pełna ciepła opowieść o życiu zabawek, które ożywają, gdy ludzie nie patrzą. Woody i Buzz Astral uczą się, co znaczy prawdziwa przyjaźń, podczas emocjonujących przygód." },
        new Movie {Title = "Coco", ImageUrl = "/images/coco.jpg", Description = "Miguel, młody chłopiec marzący o zostaniu muzykiem, trafia do magicznego świata zmarłych, gdzie odkrywa sekrety swojej rodziny i piękno tradycji." },
        new Movie {Title = "The Social Network", ImageUrl = "/images/social_network.jpg", Description = "Zajrzyj za kulisy powstania Facebooka, gdzie ambicje, geniusz i zdrady prowadzą do stworzenia jednego z największych serwisów społecznościowych na świecie." },
        new Movie {Title = "Kraina lodu", ImageUrl = "/images/frozen.jpg", Description = "Anna wyrusza na niebezpieczną wyprawę, aby odnaleźć swoją siostrę Elsę, która przypadkowo zamroziła ich królestwo w wiecznej zimie. Pełna magii opowieść o rodzinie i miłości." },
        new Movie {Title = "Czarna Pantera", ImageUrl = "/images/black_panther.jpg", Description = "T'Challa, nowy król Wakandy, musi zmierzyć się z zagrożeniem wewnętrznym i zewnętrznym, aby chronić swoje królestwo oraz jego zaawansowaną technologię." },
        new Movie {Title = "Doktor Strange", ImageUrl = "/images/doctor_strange.jpg", Description = "Stephen Strange, utalentowany chirurg, po tragicznym wypadku odkrywa świat mistycznych sztuk i staje się potężnym czarodziejem." },
        new Movie {Title = "Strażnicy Galaktyki", ImageUrl = "/images/guardians.jpg", Description = "Zespół wyrzutków z różnych zakątków galaktyki jednoczy się, aby powstrzymać potężnego złoczyńcę przed zdobyciem wszechmocnego artefaktu." },
        new Movie {Title = "Iron Man", ImageUrl = "/images/iron_man.jpg", Description = "Tony Stark, genialny wynalazca i miliarder, tworzy zaawansowaną zbroję, aby walczyć z przestępczością i ochronić świat." },
        new Movie {Title = "Kapitan Ameryka: Zimowy żołnierz", ImageUrl = "/images/captain_america.jpg", Description = "Kapitan Ameryka odkrywa spisek wewnątrz S.H.I.E.L.D. i musi stawić czoła tajemniczemu Zimowemu Żołnierzowi." },
        new Movie {Title = "Spider-Man: Homecoming", ImageUrl = "/images/spiderman.jpg", Description = "Peter Parker, młody superbohater, uczy się, jak łączyć życie licealisty z obowiązkami Spider-Mana, walcząc z nowym wrogiem." },
        new Movie {Title = "Thor: Ragnarok", ImageUrl = "/images/thor.jpg", Description = "Thor musi uwolnić się z kosmicznego więzienia i powstrzymać Ragnarok - zagładę Asgardu, z pomocą nieoczekiwanych sojuszników." },
        new Movie {Title = "Wonder Woman", ImageUrl = "/images/wonder_woman.jpg", Description = "Diana Prince opuszcza swoją wyspę Amazonek, aby pomóc światu w czasie I wojny światowej i odkryć swoje przeznaczenie jako Wonder Woman." },
        new Movie {Title = "Deadpool", ImageUrl = "/images/deadpool.jpg", Description = "Sarkastyczny najemnik z nadludzką zdolnością regeneracji wyrusza na misję zemsty na człowieku, który go oszpecił." },
        new Movie {Title = "Logan", ImageUrl = "/images/logan.jpg", Description = "Logan, starzejący się Wolverine, podejmuje ostatnią misję, aby ochronić młodą mutantkę przed bezwzględnym wrogiem." },
        new Movie {Title = "Joker", ImageUrl = "/images/joker.jpg", Description = "Przełomowa opowieść o początkach Jokera, ukazująca jego drogę od marginalizacji społecznej do stania się ikoną chaosu." },
        new Movie {Title = "Batman", ImageUrl = "/images/batman.jpg", Description = "Młody Bruce Wayne rozpoczyna swoją misję jako mroczny rycerz Gotham, walcząc z przestępcami i budując swoją legendę." },
        new Movie {Title = "Shazam!", ImageUrl = "/images/shazam.jpg", Description = "Billy Batson, nastolatek, zyskuje zdolność przemiany w dorosłego superbohatera dzięki magicznemu słowu 'Shazam'." },
        new Movie {Title = "Aquaman", ImageUrl = "/images/aquaman.jpg", Description = "Arthur Curry odkrywa swoje dziedzictwo jako władca Atlantydy i wyrusza na misję zjednoczenia podwodnych królestw." },
        new Movie {Title = "Flash", ImageUrl = "/images/flash.jpg", Description = "Barry Allen, najszybszy człowiek na świecie, używa swoich mocy, aby naprawić przeszłość i uratować przyszłość." },
        new Movie {Title = "Fantastyczne zwierzęta", ImageUrl = "/images/fantastic_beasts.jpg", Description = "Newt Scamander przybywa do Nowego Jorku z magicznymi stworzeniami, które przypadkowo zostają uwolnione." },
        new Movie {Title = "Diuna", ImageUrl = "/images/dune.jpg", Description = "Paul Atreides wyrusza na pustynną planetę Arrakis, aby odkryć swoje przeznaczenie i walczyć o przetrwanie swojego rodu." },
        new Movie {Title = "Blade Runner 2049", ImageUrl = "/images/blade_runner.jpg", Description = "Nowy łowca androidów odkrywa długo skrywany sekret, który może zmienić oblicze przyszłości ludzkości." },
        new Movie {Title = "Irlandczyk", ImageUrl = "/images/irishman.jpg", Description = "Historia Franka Sheerana, płatnego mordercy, który wspomina swoje życie pełne zdrady i lojalności w świecie mafii." },
        new Movie {Title = "Parasite", ImageUrl = "/images/parasite.jpg", Description = "Rodzina z marginesu społecznego wkrada się w życie bogatej rodziny, co prowadzi do serii nieprzewidywalnych wydarzeń." },
        new Movie {Title = "1917", ImageUrl = "/images/1917.jpg", Description = "Dwóch żołnierzy otrzymuje misję przekazania wiadomości, która może uratować setki istnień podczas I wojny światowej." },
        new Movie {Title = "Na noże", ImageUrl = "/images/knives_out.jpg", Description = "Ekscentryczny detektyw bada tajemnicze morderstwo patriarchy bogatej rodziny, odkrywając złożone relacje między jej członkami." },
        new Movie {Title = "Tenet", ImageUrl = "/images/tenet.jpg", Description = "Agent tajnej organizacji używa technologii odwracania czasu, aby zapobiec globalnej katastrofie." },
        new Movie {Title = "Co w duszy gra", ImageUrl = "/images/soul.jpg", Description = "Joe Gardner, nauczyciel muzyki, trafia do zaświatów, gdzie odkrywa prawdziwy sens życia i swojej pasji." },
        new Movie {Title = "Ratatuj", ImageUrl = "/images/ratatouille.jpg", Description = "Remy, szczur z talentem kulinarnym, nawiązuje niezwykłą współpracę z młodym kucharzem w eleganckiej paryskiej restauracji." },

    };

    public List<Movie> GetAllMovies()
    {
        return movies;
    }

    public Movie GetMovieById(int id)
    {
        return movies.FirstOrDefault(m => m.Id == id);
    }

    internal object GetMovieById(object id)
    {
        throw new NotImplementedException();
    }
}