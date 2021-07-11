# Laboratoire .Net 2021 : Gestionnaire de centre de vaccination ![](Aspose.Words.34d78b6a-71e6-497d-add4-6983d22d66e2.001.png)

Suite à des soucis organisationnels, notre client : la région Wallonne ; nous demande de lui fournir une plateforme de gestion pour ces centres de vaccination. 

Cette plateforme est divisée en deux grandes parties : 

L’espace membre du personnel : 

Sous forme d’une application ASP.net MVC, elle donne accès aux informations dont le personnel du centre doit avoir accès pour organiser au mieux le centre. 

L’espace patient : 

Sous forme d’une application ASP.net WebAPI, elle permettra aux futures plateformes (Angular ou Mobile – iOs et Android), d’échanger des informations avec la base de données, concernant les patients. 

La base de données sera de technologie SQL Server, et contiendra l’ensemble des données (celle des centres, des membres du personnel et des patients). 

Le personnel, tout comme les patients doivent avoir un accès sécurisé. Un grand nombre de données sensibles sont enregistrées dans la base de donnée, garantissez leur protection. 

Les patients doivent s’inscrire sur l’application pour obtenir une invitation aux rendez-vous de vaccination. Ceux-ci doivent être fixé avec maximum 30 jours d’écart. Le patient peut choisir le Centre, la date et l’heure (au quart d’heure près). 

Un centre ne peut fournir plus de 10 rendez-vous à la même heure. Lors de la vaccination d’un patient, le personnel soignant ayant injecté la dose doit enregistrer l’identifiant de lot de la dose, ainsi que son nom. 

Les informations suivantes doivent être accessible par tous (Patients, soignants ou visiteurs) : 

- Répertoire des centres de la région Wallonne 
- Adresse 
- Horaires 
- Vaccins fournis 
- Responsable 

Seul les membres du personnel doivent avoir accès aux fonctionnalités suivantes : 

- Liste du personnel de chaque centre 
  - Nom et prénom 
  - Grade (Médecin, infirmier, sécurité, bénévole) 
  - Numéro INAMI (si personnel médical) 
- Gestion du stock des vaccins 
- Fournisseur (Fabricant, Adresse entrepôt) 
- Identifiant de lot 
- Log d’entrée en stock (date et quantité)  
- Log de sortie du stock (date et quantité) 

Les données accessible aux patients sont : 

- Inscription à la vaccination 
  - Numéro de registre national 
  - Nom, prénom, date de naissance 
  - Moyen de communication (Téléphone, e-mail) 
  - Adresse 
  - Indications médicales (Allergies, syndromes, antécédents, …) 
- Planification des injections 
  - Vaccins fournis 
  - Centre 
  - Dates 
  - Heures 
- Accès aux dossier médical du patient 
- Résumé des injections 
