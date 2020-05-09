function AddRow() {
    $(".test").append(
        "<tr>" +
        '<td><input class="form-control text-box single-line" data-val="true" data-val-required="The Adresas field is required." id="newArenasArray_Adresas" name="newArenasArray.Adresas" type="text" value=""></td>' +
        '<td><input class="form-control text-box single-line" data-val="true" data-val-required="The Miestas field is required." id="newArenasArray_Miestas" name="newArenasArray.Miestas" type="text" value=""></td>' +
        '<td><input class="form-control text-box single-line" data-val="true" data-val-number="The field ID must be a number." data-val-required="The ID field is required." id="newArenasArray_Miesto_ID" name="newArenasArray.Miesto_ID" type="number" value=""></td>' +
        '<td><input class="form-control text-box single-line" data-val="true" data-val-required="The Pavadinimas field is required." id="newArenasArray_Pavadinimas" name="newArenasArray.Pavadinimas" type="text" value=""></td>' +
        '<td><input class="form-control text-box single-line" data-val="true" data-val-number="The field Talpa must be a number." data-val-required="The Talpa field is required." id="newArenasArray_Talpa" name="newArenasArray.Talpa" type="number" value=""></td>' +
        "</tr>"
    );
}