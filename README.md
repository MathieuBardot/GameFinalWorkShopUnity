Définition du jeu de type FireEmblem :

- plateau de 10*10 
- classe pour avoir les différents personnages
	- caractéristique de base : nom, force, defense, etc
	- définiton d'un mouvement (nombres de cases qu'on peut parcourir un tour au max)
	- définition d'une capacité
		- archer peut attaquer en étant 1 case en arrière (du coup précision de l'adversaire  faible)	
		- cavalier peut avancer plus loin
		- chevalier peut maximiser sa défense
- interface de combat (sur base de celui fait en cours) avec notamment un nombre de 3 coups max
- interface textuelle pour dire ce qui se passe en jeu (déplacement, déclenchement combat, stats du perso)
- sur le plateau de jeu
	- possibilités de mouvement des perso (nombre de cases possibles ou pas)
	- désigner un personnage avec la souris pour avoir ces infos (accés à l'interface textuelle en appuyant sur la case)
	- après choix du personnage, cliquer avec la souris sur l'emplacement choisi
- placer 3 perso de par et d'autres du terrain (positions à fixer au départ)
- système au tour par tour :
	- chaque personnage peut faire un mouvement et si possible attaquer un ennemi
	- On peut passer son tour
- condition de victoire/ défaite : tous les perso d'un joueur battu
- optionnels ajours d'items pour booster ou afflaibir des personnages

Fonctionnalités implémenter :
- le système de combat au tour par tour sous forme d'interface avec 1 coup possible par round
- l'interface permettant d'avoir les infos du personnages sélectionnés
- un plateau 10*10 de générer

Différentes scénes pour vérifier les différentes fonctionnalités:
- UserInterfaceWithBattle = contient le panel d'info avec un personnage de départ et possbilités de déclencher un combat avec un ennemi 
- TestPathFinding = contient différents tests d'algorithmes de Pathfinding pour pouvoir fixer et sélectionner les chemins des personnages possibles sur une grille 
- UserInterfaceWithPlateau = contient l'ensemble des parties fonctionnelles à savoir
	- le plateau avec 3 personnages des 2 côtés
	- possibilités de sélectionnner un personnage avec la souris pour avoir le panel d'informations avec les informations correspondant
