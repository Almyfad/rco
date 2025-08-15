-- reformatintra.`sync.listing.to.Membres` source
CREATE
OR REPLACE ALGORITHM = UNDEFINED VIEW `reformatintra`.`sync.listing.to.Membres` AS
select
    `l`.`listing_id` AS `Id`,
    case
        `l`.`listing_civilite`
        when 'Mme' then 200
        when 'M.' then 100
        when 'Mr' then 100
        else 100
    end AS `CiviliteId`,
    `l`.`listing_nom` AS `Nom`,
    `l`.`listing_prenom` AS `Prenom`,
    case
        `l`.`listing_categorie`
        when '1er aspect' then 100
        when '2ème aspect' then 200
        when 'ECS' then 300
        when 'Ecclesia' then 400
        when 'Graal' then 500
        when '5ème aspect' then 600
        when '6ème aspect' then 700
        when 'Sympathisant' then 900
        when 'Contact' then 950
        when 'Enfant bébé' then 1000
        when 'Enfant groupe pré-A' then 1050
        when 'Enfant groupe A' then 1100
        when 'Enfant groupe B' then 1200
        when 'Enfant groupe C' then 1300
        when 'Enfant groupe D' then 1400
        when 'Enfant hors groupe' then 1500
        when 'Groupe D' then 1600
        when 'Groupe D+' then 1700
        else 100
    end AS `TypeMembreId`,
    case
        `l`.`listing_statut`
        when 'Présent' then 100
        when 'Present' then 100
        when 'Suivi' then 200
        when 'Absent' then 300
        when 'Démissionnaire' then 400
        when 'Demissionnaire' then 400
        when 'Décédé' then 500
        when 'Decede' then 500
        else 100
    end AS `StatutMembreId`,
    case
        `l`.`listing_centre`
        when 'Poitiers' then 2
        when 'Paris' then 4
        when 'Lyon' then 5
        when 'Marseille' then 6
        when 'Toulouse' then 7
        when 'Guadeloupe' then 8
        when 'Aix-en-Provence' then 9
        when 'Lille' then 10
        when 'Metz' then 11
        when 'Montptelier' then 12
        when 'Perpignan' then 13
        when 'CotedAzur' then 14
        when 'Rennes' then 15
        when 'Rouen' then 16
        when 'Strasbourg' then 17
        else NULL
    end AS `CentreId`,
    `l`.`listing_email` AS `Email`,
    `l`.`listing_profession` AS `Profession`,
    `l`.`listing_telephone` AS `Telephone`,
    `l`.`listing_portable` AS `Portable`,
    `l`.`listing_adresse_1` AS `Adresse`,
    `l`.`listing_cp` AS `CodePostal`,
    `l`.`listing_ville` AS `Ville`,
    `l`.`listing_pays` AS `Pays`,
    case
        `l`.`listing_email_statut`
        when 'valide' then 1
        else 0
    end AS `EmailValide`,
    `l`.`listing_connaissances` AS `Connaissances`,
    `l`.`listing_remarques` AS `Commentaires`,
    nullif(`l`.`listing_date_naissance`, '0000-00-00') AS `DateNaissance`,
    current_timestamp() AS `Creation`,
    nullif(`l`.`listing_last_modif`, '0000-00-00') AS `Modification`
from
    `reformatintra`.`listing` `l`;