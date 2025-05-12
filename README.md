# PhoenixTS93 - automatyczne przechodzenie TS93

Aplikacja Windows Forms do łączenia się z klientem PhoenixBot i wykonywania czasoprzestrzeni 93 (TS93).

## Autorzy
- XaV
- ChatGPT

## Jak działa

- Automatyczne wykrywanie klienta Phoenix poprzez PhoenixIPC.json.
- Połączenie TCP do klienta i wysłanie komendy rozpoczęcia TS93.
- Logowanie błędów do pliku `debug.log`.

## Kompilacja automatyczna
GitHub Actions zbuduje `.exe` automatycznie po każdym pushu.
