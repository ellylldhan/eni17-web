# TP4 Pizza v1 (m5tp2)
*TP 02 du Module 5 - Razor*

_**Durée estimée** : 1 à 3 heures_

### Objectifs
Le but est de créer un site pour la gestion de pizzas

- Créer, modifier, supprimer des pizza
- Afficher la liste de toutes les pizzas créées

### Enoncé
- [x] Créer un nouveau site web ASP.Net MVC sans authentification
- [x] Dans la solution, **importer** le projet `BO` fourni
- [x] Générer un **contrôleur** avec actions de lecture/écriture nommé `PizzaController`
- [x] En utilisant les getters statiques de la classe `Pizza`, mettre en place une "simulation de persistance de données" dans notre `PizzaController` (**FakeDb** ?!)
- [x] Générer les **vues** `Create`, `Edit`, `Delete`, `Index` pour notre `PizzaController`
- [ ] Modifier ces vues pour **ajouter le choix de la pâte et des ingrédients** dans les vues `Edit` et `Create` en utilisant des `ViewModels`
- [ ] Dans le contrôleur, ajouter le code nécessaire pour **rendre fonctionnelles toutes les actions** pré-générées. Penser à factoriser le code.
- [ ] Créer une **vue partielle** pour l'affichage des **détails** d'une pizza en lecture seule. Elle doit afficher également la pâte sélectionnée et la liste des ingrédients.
- [ ] **Modifier les vues** `Edit` et `Details` pour qu'elles utilisent cette vue partielle.
- [ ] Ajouter un **lien dans la navbar** du `_layout` afin d'afficher l'action <kbd>Index</kbd>

### Pour aller plus loin
- [ ] Créer une **méthode d'extension** sur la classe `HtmlHelper` permettant de générer le code HTML pour le bouton <kbd>Submit</kbd> des formulaires, avec en paramètre le libellé du bouton.
    + [ ] Cas d'utilisation dans un fichier cshtml : `@Html.CustomSubmit("Sauvegarder")`
    + [ ] Vous aurez besoin d'ajouter un `@using` au début de votre vue pour recenser la classe de la méthode d'extension.
- [ ] Modifier tous les `actionLink` des vues CRUD pour **afficher un bouton plutôt qu'un hyperlien**.