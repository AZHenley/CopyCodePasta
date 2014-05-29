CopyCodePasta
=============

Dynamic COPY and PASTE with variables.

This changes the pasted text every time you paste. Usually, this is so that a number is incremented each time.

It supports an unlimited number of variables. The syntax for a new variable is:
$$varname,0,1$$
$$ escapes. varname is the variable name, the initial value, and how much to increment each time you paste.
To use an existing variable:
$$varname$$



Here is an example:
Hello$$alpha,0,1$$, World$$beta,9,3$$! $$alpha$$

The example's output:
Hello0, World9! 0
Hello1, World12! 1
Hello2, World15! 2
