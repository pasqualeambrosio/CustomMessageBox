# CustomMessageBox

This Windows Form simulate a MessageBox but allows to add details information.

![CustomMessageBox With Details](https://github.com/pasqualeambrosio/CustomMessageBox/blob/main/custom%20message%20box%20with%20details.jpg)

### Setup button text
By default the text of buttons are in English.
To customize languages set the var `CustomMessageBox.CustomMessageDictionay`

```
CustomMessageBox.CustomMessageDictionay.btnOk = "Ok";
CustomMessageBox.CustomMessageDictionay.btnYes = "Si";
CustomMessageBox.CustomMessageDictionay.btnNo = "No";
CustomMessageBox.CustomMessageDictionay.btnCancel = "Annulla";
CustomMessageBox.CustomMessageDictionay.btnAbort = "Abortisci";
CustomMessageBox.CustomMessageDictionay.btnRetry = "Riprova";
CustomMessageBox.CustomMessageDictionay.btnIgnore = "Ignora";
CustomMessageBox.CustomMessageDictionay.btnDetails = "Dettagli";
```

### Call CustomMessageBox - version 1
This version can be used to 'replace' the actual MessageBox call.

```
if (CustomMessageBox.Show("Are you sure to continue?",
                          "Info",
                          "The operation is irreversible",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question,
                          MessageBoxDefaultButton.Button2) == DialogResult.Yes)
{
    CustomMessageBox.Show("Done!");
}
else
{
    CustomMessageBox.Show("Operation annulled!");
}
```

### Call CustomMessageBox - version 2
This version use a object as parameters.
```
CustomMessageBox.Show(new CustomMessageBox.CustomMessageBoxParams
{
    text = "Continue?",
    buttons = MessageBoxButtons.YesNo
});
```
