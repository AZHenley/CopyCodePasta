CopyCodePasta
=============

This tool allows you to copy and paste text that changes everytime you paste. Think of it as a dynamic clipboard with integer variables. It works great for macros or when it would be too much effort to write a fully automated script.

Let's say I want to paste `Id=X, Name=X, Column=Y` where X increases by 1 each time I paste and Y increases by 3.

You would enter the text: `Id=$$x,0,1$$, Name=$$x$$, Column=$$y,1,3$$` and click *Start*.

What this does is create a variable *x*, that starts at 0 and increments by 1 each time you paste. *x* is referenced in two places (Id and Name). It also creates a variable *y*, that starts at 0 but increments by 3.

Now if you go paste (press Ctrl+V) three times you will get:
 - Id=0, Name=0, Column=1
 - Id=1, Name=1, Column=4
 - Id=2, Name=2, Column=7

Another simple example: `Paste number: $$count,1,1$$`
- Paste number: 1
- Paste number: 2
- Paste number: 3


Only integers are supported without any expressions or conditionals.

![Screenshot of CopyCodePasta](https://github.com/AZHenley/CopyCodePasta/blob/master/copycodepasta_screenshot.png "Screnshot of CopyCodePasta")
