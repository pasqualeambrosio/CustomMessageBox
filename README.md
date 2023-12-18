# CustomMessageBox

This Windows Form allow to simulate a MessageBox with details box.

![CustomMessageBox With Details](https://github.com/pasqualeambrosio/CustomMessageBox/blob/main/custom%20message%20box%20with%20details.jpg)

## Setup button text
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

## Call CustomMessageBox - version 1
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

## Call CustomMessageBox - version 2
```
CustomMessageBox.Show(new CustomMessageBox.CustomMessageBoxParams
{
    text = "Continue?",
    buttons = MessageBoxButtons.YesNo
});
```
