CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "Atores" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Atores" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "BirthDate" TEXT NULL,
    "Nationality" TEXT NULL,
    "Gender" TEXT NULL,
    "AwardsCount" INTEGER NOT NULL
);

CREATE TABLE "Diretores" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Diretores" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Filmes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Filmes" PRIMARY KEY AUTOINCREMENT,
    "Titulo" TEXT NOT NULL,
    "Ano" INTEGER NOT NULL,
    "DiretorId" INTEGER NOT NULL,
    CONSTRAINT "FK_Filmes_Diretores_DiretorId" FOREIGN KEY ("DiretorId") REFERENCES "Diretores" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AtorFilme" (
    "AtoresId" INTEGER NOT NULL,
    "FilmesId" INTEGER NOT NULL,
    CONSTRAINT "PK_AtorFilme" PRIMARY KEY ("AtoresId", "FilmesId"),
    CONSTRAINT "FK_AtorFilme_Atores_AtoresId" FOREIGN KEY ("AtoresId") REFERENCES "Atores" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AtorFilme_Filmes_FilmesId" FOREIGN KEY ("FilmesId") REFERENCES "Filmes" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_AtorFilme_FilmesId" ON "AtorFilme" ("FilmesId");

CREATE INDEX "IX_Filmes_DiretorId" ON "Filmes" ("DiretorId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250110144825_inicial', '9.0.0');

COMMIT;