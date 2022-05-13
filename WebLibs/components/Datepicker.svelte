<script>
    export let Height = 30;
    export let Placeholder = "";
    export let Value = "";
    export let Width = 120;

    const backgroundNormal = "#FFFFFF";
    const backgroundFalschesDatum = "#FF0000";
    
    let monate = ["Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"];
    let montateKurz = ["Jan", "Feb", "Mär", "Apr", "Mai", "Jun", "Jul", "Aug", "Sep", "Nov", "Dez"];
    let tage = ["Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sontag"];
    let tageKurz = ["Mo", "Di", "Mi", "Do", "Fr", "Sa", "So"];

    let inputField, buttonStyle, divStyle, inputStyle;
    let background = backgroundNormal;
    let buttonHeight = Height - 6;
    let buttonImageHeight = Height - 10;
    let datePickerHidden = true;
    let errorHidden = true;
    let inputHeight = Height - 2;
    let inputWidth = Width - Height - 10;

    let allowedNumbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"];
    let allowedTage = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    let allowedTageSchaltjahr = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    let allowedSonderzeichen = ".";
    let allowedFunctionalKeys = ["ArrowLeft", "ArrowRight", "Backspace", "Delete"];
    let currentJahr = new Date().getFullYear();
    let currentMonat = monate[new Date().getMonth()];
    let wochenImMonat = [];
    let monatIndex = 0;

    function alertFalschesDatum()
    {
        background = backgroundFalschesDatum;
        errorHidden = false;
        setFieldStyle();
    }
    function backToNormal()
    {
        background = backgroundNormal;
        errorHidden = true;
        setFieldStyle();
    }
    function checkGueltigesDatum()
    {
        let error = false;
        let inhalt = Value.split(allowedSonderzeichen);
        let localTag = inhalt[0];
        let localMonat = inhalt[1];
        let localJahr = inhalt[2];

        if(inhalt.length == 1 && Value.length == 2)
        {
            Value = Value + allowedSonderzeichen;
        }
        if(inhalt.length == 2 && localMonat.toLocaleString().length >= 2)
        {
            Value = Value + allowedSonderzeichen;
        }

        // Prüfung, ob der Monat korrekt eingegeben wurde
        if(localMonat != "undefined" && (localMonat < 1 || localMonat > 12))
        {
            error = true;
        }
        else
        {
            error = false;
        }

        // Prüfung, ob der Tag korrekt eingegeben wurde
        if(localTag < 1 || localTag > 31)
        {
            error = true;
        }

        if(localMonat != "undefined")
        {
            let localAllowedTage = allowedTage[inhalt[1]];
            if(localAllowedTage == "undefined")
            {
                error = true;
            }
            if(localTag > localAllowedTage)
            {
                error = true;
            }
        }

        if(error)
        {
            alertFalschesDatum();
        }
        else
        {
            backToNormal();
        }
    }
    function daysInMonth()
    {
        wochenImMonat = [];
        monatIndex = monate.findIndex(item => item == currentMonat) + 1;
        let tageImMonat = new Date(currentJahr, monatIndex, 0).getDate();
        let localTagIndex = 0;
        let woche = [];
        let tagesWochenCounter = 0;

        for(let counter = 0; counter < tageImMonat; counter++)
        {
            localTagIndex = new Date(currentJahr, monatIndex-1, counter).getDay();
            if(counter == 0)
            {
                // Am Anfang müssen erstmal x Leertage in die Woche eingefügt werden, damit der Monat 
                // am passenden Wochentag startet => das macht es in der Anzeigeschleife leichter
                for(let bufferCounter = 0; bufferCounter < localTagIndex; bufferCounter++)
                {
                    woche = [...woche, ''];
                }
            }
            woche = [...woche, counter+1];

            tagesWochenCounter++;
            if(woche.length >= 7)
            {
                wochenImMonat = [...wochenImMonat, woche]
                woche = [];
                tagesWochenCounter = 0;
            }
            if(counter == tageImMonat-1)
            {
                wochenImMonat = [...wochenImMonat, woche]
                woche = [];
                tagesWochenCounter = 0;
            }
        }
    }
    function ignoreInput(e)
    {
        e.preventDefault();
        e.returnValue = false;
    }
    function setFieldStyle()
    {
        buttonStyle = "background: transparent; border: 0px; height: " + buttonHeight + "px; margin-left: 10px; margin-right: 8px; margin-top: 0px; width: " + buttonHeight + "px;";
        divStyle = "background: white; border: 0.5px solid lightgray; border-radius: 5px; display: flex; height: " + Height + "px; width: " + Width + "px;";
        inputStyle = "background: " + background + "; border: 0px; height: " + inputHeight + "px; width: " + inputWidth + "px;";
    }
    function setJahr(selectedJahr)
    {
        currentJahr = selectedJahr.currentJahr;
        daysInMonth();
    }
    function setMonat(selectedMonat)
    {
        currentMonat = selectedMonat.currentMonat;
        daysInMonth();
    }
    function setPlaceholder(tag)
    {
        if(tag != "")
        {
            //Placeholder = getFormattedDate(tag);
        }
    }
    function setValue(tag)
    {
        Value = new Date(currentJahr+"-"+currentMonat+"-"+tag);
        datePickerHidden = true;
        backToNormal();
    }
    function thisKeyDown(e)
	{
        if(allowedNumbers.includes(e.key) == true)
        {
            let inhalt = Value.split(allowedSonderzeichen);
            if(Value.length >= 10)
            {
                ignoreInput(e);
            }
            checkGueltigesDatum();
        }
        else if (e.key == allowedSonderzeichen)
        {
            // Kann nicht mit einer && Verknüpfung in die else if-Bedingung gepackt werden, da sonst gar kein Sonderzeichen mehr erlaubt ist... warum auch immer.
            if(Value.split(allowedSonderzeichen).length >= 3)
            {
                ignoreInput(e);
            }
        }
        else if (allowedFunctionalKeys.includes(e.key) == true) { }
        else 
        {
            ignoreInput(e);
        }
	}
    function getValueFormatted(oldValue)
    {
        let localTag = (new Date(oldValue).getUTCDate()).toString();
        let localMonat = (new Date(oldValue).getMonth()+1).toString();
        let localJahr = new Date(oldValue).getUTCFullYear().toString();

        if(localMonat.length < 2)
        {
            localMonat = "0" + localMonat;
        }
        if(localTag.length < 2)
        {
            localTag = "0" + localTag;
        }
        return localTag + "." + localMonat + "." + localJahr;
    }

    $:if(true)
    {
        setFieldStyle();
        daysInMonth(currentMonat, currentJahr);
    }
    $:if(Value)
    {
        Value = getValueFormatted(Value);
    }
</script>

<div style={divStyle}>
    <input bind:this={inputField} type="text" style={inputStyle} placeholder={Placeholder} bind:value={Value} on:keydown={thisKeyDown}>
    <button style={buttonStyle} on:click={() => datePickerHidden = !datePickerHidden}>
        <img src="calendar.png" alt="" height={buttonImageHeight}>
        <!-- [...] -->
    </button>

    <div class="card" hidden={errorHidden} style="margin-top: 40px; position:absolute;">
        Ungültiges Datum
    </div>
</div>
<div class="card" hidden={datePickerHidden} style="background: white; border: 1px solid black; border-radius: 10px; margin-top: 5px; position:absolute;">
    <div style="margin: 10px;">
        <div style="display: flex;">
            <select class="buttonMonthSelected" bind:value={currentMonat} on:click={() => setMonat({currentMonat})}>
                {#each monate as monatAuswahl}
                    <option class="buttonMonthSelector">{monatAuswahl}</option>
                {/each}
            </select>
            <input type="number" style="height: 40px; margin-left: 10px; width: 85px;" bind:value={currentJahr} on:click={() => setJahr({currentJahr})}>
        </div>
        <br>
        <table>
            <tr>
                {#each tageKurz as tag}
                    <td><b>{tag}</b></td>
                {/each}
            </tr>
            {#each wochenImMonat as woche}
            <tr>
                {#each woche as tageInWoche}
                    <td>
                        <button class="buttonTag" on:mouseover={() => setPlaceholder(tageInWoche)} on:click={() => setValue(tageInWoche)}>
                            {tageInWoche}
                        </button>
                    </td>
                {/each}
            </tr>
            {/each}
        </table>
    </div>
</div>

<style>
    td, tr{
        margin: 0px;
        padding: 0px;
    }
    .buttonTag{
        background-color: transparent;
        border: 0px;
        height: 35px;
        text-align: center;
        width: 35px;
    }
    .buttonTag:hover{
        background-color:cornflowerblue;
        color: white;
    }
    .buttonMonthSelected{
        background-color: transparent;
        border-radius: 5px;
        text-align: left;
        width: 115px;
    }
    .buttonMonthSelector{
        background-color: transparent;
        border: 0px;
        text-align: left;
        width: 115px;
    }
    .buttonMonthSelector:hover{
        background-color:cornflowerblue;
        color: white;
    }
</style>