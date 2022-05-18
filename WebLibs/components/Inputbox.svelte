<script>
    export let AllowedDecimals = 2;
    export let DecimalTrenner = ",";
    export let KeyDownFunctionOnEnter, KeyDownFunctionOnTab;
    export let Height = 30;
    export let IsPflichtfeld = false;
    export let IsVorzeichenErlaubt = true;
    export let MinValue = 0;
    export let MaxValue = 0;
    export let Multiline = false;
    export let Type = "text";
    export let Value = "";
    export let Width = 120;

    let errorHidden = true;
    let errorMessage = "";
    let style = "height: " + Height + "px; width: " + Width + "px;";
    let styleError = "width: " + Width + "px;";
    let tausenderTrenner = ".";

    let allowedNumbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8,", "9"];
    let allowedDecimalTrenner = [",", "."];
    let allowedFunctionalKeys = ["ArrowLeft", "ArrowRight", "Backspace", "Delete"];
    let allowedVorzeichen = "-";

    function checkInput(e)
    {
        switch(Type)
        {
            case "currency":
            case "number":
                checkInputNumber(e);
                break;

            case "email":
                checkInputEMail(e)
                break;
        }

        executeAdditionalFunctions(e);
    }
    function checkInputNumber(e)
    {
        let localValueString = Value.toLocaleString();
        
        // Prüfung auf Ziffern
        if(allowedNumbers.includes(e.key) == true)
        {
            if(isBetweenMinMax(e))
            {
                let positionDezimalTrenner = localValueString.indexOf(DecimalTrenner)
                if(positionDezimalTrenner > -1)
                {
                    let decimals = localValueString.substring(positionDezimalTrenner);
                    if(decimals.length > AllowedDecimals || (Type == "currency" && decimals.length > 2))
                    {
                        ignoreInput(e);
                    }
                }
            }
            else
            {
                ignoreInput(e);
            }
        }
        
        // Prüfung auf Dezimaltrenner
        else if (allowedDecimalTrenner.includes(e.key) == true)
        {
            if(localValueString.split(DecimalTrenner).length >= 2)
            {
                ignoreInput(e);
            }
            else if(e.key != DecimalTrenner)
            {
                ignoreInput(e);
            }
        }

        // Prüfung auf Vorzeichen
        else if (IsVorzeichenErlaubt && e.key == allowedVorzeichen)
        {
            if(!isBetweenMinMax(e))
            {
                ignoreInput(e);
            }
            else if(localValueString.startsWith(e.key))
            {
                ignoreInput(e);
            }
            else
            {
                Value = e.key + Value;
                ignoreInput(e);
            }
        }

        // Prüfung auf Funktionstasten wie [ENTF], [DEL], usw.
        else if (allowedFunctionalKeys.includes(e.key) == true) { }

        // Alles andere soll nicht erlaubt sein
        else
        {
            ignoreInput(e);
        }
    }
    function checkInputEMail(e)
    {
        let mailParts = Value.split("@");
        errorHidden = false;    // Pauschal einen Fehler anzeigen lassen - spart Codezeilen

        if(mailParts[0].length > 64)
        {
            errorMessage = "Der Lokalteil der E-Mail Adresse (vor dem @-Zeichen) darf eine Maximallänge von 64 Zeichen nicht überschreiten."
        }
        else if(mailParts.length > 1 && mailParts[0].length < 1)
        {
            errorMessage = "Der Lokalteil der E-Mail Adresse (vor dem @-Zeichen) muss eine Mindestlänge von 1 Zeichen besitzen."
        }
        else if(mailParts.length > 1 && !mailParts[1].includes("."))
        {
            errorMessage = "Der Domainteil der E-Mail Adresse (nach dem @-Zeichen) muss einen Punkt (.) enthalten."
        }
        else if(Value.startsWith(".") || Value.endsWith("."))
        {
            errorMessage = "Die E-Mail Adresse darf mit einem Punkt weder beginnen noch enden."            
        }
        else if(Value.startsWith("@") || Value.endsWith("@"))
        {
            errorMessage = "Die E-Mail Adresse darf mit einem @-Zeichen weder beginnen noch enden."            
        }
        else if(!Value.includes("@") && e.key != "@")
        {
            errorMessage = "@-Zeichen muss enthalten sein."
        }
        else if(Value.length > 253)
        {
            errorMessage = "Maximallänge: 254 Zeichen.";
        }
        else if(Value.length < 6)
        {
            errorMessage = "Mindestlänge: 6 Zeichen.";
        }
        else
        {
            errorHidden = true;
            errorMessage = ""; // einfach für die Sauberkeit
        }
    }
    function executeAdditionalFunctions(e)
    {
        switch(e.key)
		{
			case "Enter":
                if(typeof(KeyDownFunctionOnEnter) != 'undefined')
                {
                    KeyDownFunctionOnEnter();
                }
				break;
			case "Tab":
                if(typeof(KeyDownFunctionOnTab) != 'undefined')
                {
                    KeyDownFunctionOnTab();
                }
				break;
		}
    }
    function ignoreInput(e)
    {
        e.preventDefault();
        e.returnValue = false;
    }
    function isBetweenMinMax(e)
    {
        let isBetween = true;
        let localValueString = Value.toLocaleString()

        if(e.key == allowedVorzeichen)
        {
            localValueString = e.key + localValueString;
        }
        else
        {
            localValueString = localValueString + e.key;
        }

        // Replace wird benötigt, da sonst der Vergleich das deutsche "," als Dezimaltrenner nicht erkennt und ignoriert.
        localValueString = localValueString.replaceAll(",",".");

        if(MinValue == MaxValue || MinValue > MaxValue)
        {
            return isBetween;
        }
        else if(localValueString < MinValue)
        {
            Value = MinValue;
            isBetween = false;
        }
        else if(localValueString > MaxValue)
        {
            Value = MaxValue;
            isBetween = false;
        }
        return isBetween;
    }
    function thisKeyUp(e)
    {
        setFieldStyle();
    }
    function setFieldStyle()
    {
        console.log(Value);
        if(IsPflichtfeld && Value != "")
        {
            style = style + " background: #f5fc99;"
        }
        else if(IsPflichtfeld && Value == "")
        {
            style = style + " background: #fc5d5d;"
        }
    }

    $:if(DecimalTrenner)
    {
        // Dezimaltrenner und Tausendertrenner müssen für das US-Amerikanische Format getauscht werden
        if(DecimalTrenner == allowedDecimalTrenner[1])
        {
            tausenderTrenner = allowedDecimalTrenner[0];
        }
    }
    $:if(Type)
    {
        Type = Type.toLocaleLowerCase();
        switch(Type)
        {
            case "currency":
            case "number":
                style = style + " text-align: right;"
                break;
        }
    }
    $:if(IsPflichtfeld)
    {
        setFieldStyle();
    }
</script>

<!-- Datum -->
{#if (Type == 'date')}
<input type="date" style={style} on:keydown={checkInput} on:keyup={thisKeyUp} on bind:value={Value}/>
{/if}

<!-- Nummerisch -->
{#if (Type == 'number')}
<input style={style} on:keydown={checkInput} on:keyup={thisKeyUp} bind:value={Value}/>
{/if}

<!-- Text -->
{#if (Type == 'text' && !Multiline) || (Type == 'email')}
<input style={style} on:keydown={checkInput} on:keyup={thisKeyUp} bind:value={Value}/>
{/if}
{#if (Type == 'text' && Multiline)}
<textarea style={style} on:keydown={checkInput} bind:value={Value}/>
{/if}

<!-- Währung -->
{#if (Type == 'currency')}
<input style={style} on:keydown={checkInput} on:keyup={thisKeyUp} bind:value={Value}/>
{/if}

<div class="card" hidden={errorHidden} style={styleError}>
    {errorMessage}
</div>