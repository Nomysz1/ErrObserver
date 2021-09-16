# ErrObserver
# ErrObserver

Aplikacja powstała z myślą informowania poprzez email o wszelkiego typu błędnych importach umieszczanych w folderze err dedykowanych aplikacji. 

Aplikacja do uruchomienia potrzebuje kilka parametrów, jak 

--filepath -> Ścieżka do obserwacji w których znajdują się pliki
--extension -> rozszerzenia, które aplikacja ma brać pod uwagę
--emailAddr -> adres email z którego ma korzystać aplikacja
--smtpPort -> Port smtp serwera pocztowego
--smtpHost -> Adres serwera smtp
--ssl -> szyfrowanie (0|1)
--to -> adres email do wysyłki informacji wraz z plikiem.

Przykładowe wywołanie programu poprzez cli

app.exe --filepath C:\Test\ --extension * --emailAddr sampleMail@sampleDomain.pl --smtpPort 587 --smtpHost smtp.sample.pl --ssl 0 --to sampleTO@sample.com
