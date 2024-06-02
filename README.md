# Supermarket Management Application

Aceasta este o aplicatie C# WPF pentru gestionarea operatiunilor unui supermarket, utilizand arhitectura MVVM și SQLServer pentru baza de date. Aplicatia prezinta diferite functionalitati pentru doua tipuri de utilizatori: administrator si casier.

## Functionalitati

 Functionalitati pentru administrator:

 <ol>
     <li>
     Gestionare utilizatori, produse,categorii, producatori, stocuri: Adaugare, modificare, stergere (logica) si vizualizare.
    </li>
    <li>
     Gestionare stocuri:
    </li>
       <ul>
         <li>
           Introducere manuala a pretului de achizitie, pretul de vanzare fiind calculat automat.
         </li>
         <li>
           Pretul de achizitie nu se poate modifica dupa introducere, doar pretul de vanzare poate fi modificat si nu poate fi mai mic decat pretul de achizitie.
         </li>
       </ul>
   <li>
     Cautare si vizualizare date:
   </li>
   <ul>
     <li>
       Listarea produselor unui producator pe categorii.
     </li>
     <li>
       Afisarea valorii fiecarei categorii de produs (suma preturilor de vanzare curente).
     </li>
     <li>
       Vizualizarea sumelor incasate de un utilizator pe zi, intr-o luna selectata.
     </li>
     <li>
       Afisarea datelor de pe cel mai mare bon al zilei.
     </li>
   </ul>
 </ol>
 Functionalitati pentru casier:
 <ol>
   <li>
     Cautare produse: Cautare dupa nume, cod de bare, data expirarii, producator, categorie.
   </li>
   <li>
     Emiterea bonurilor
   </li>
     <ul>
       <li>
         Vizualizarea produselor adaugate pe bon.
       <li>
         Calcularea subtotalului si a totalului bonului automat.
       </li>
       <li>
         Dupa adaugarea unui bon, acesta nu poate fi modificat.   
       </li>
     </ul>
   <li>
     Gestionare stocuri:
   </li>
   <ul>
     <li>
       Un stoc devine inactiv cand nu mai sunt produse in el.
     </li>
     <li>
       Cantitatea de produse se modifica prin vanzarea de produse, nu manual.
     </li>
   </ul>
 </ol>
