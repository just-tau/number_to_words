# number_to_words
C# code, aids in converting number to its equivalent in words.

**Note**: 
1. It capitalizes the first letter of the first word, but does not add any special characters like comma, or full-stop
2. It uses the International number naming system, i.e., using millions,billions, etc instead of lakhs,crores,etc.
3. At very high numbers(~10 quadrillion), loss in precision maybe expected.
4. Although usable range is in the order of pentillions, optimal range is  in quadrillions, i.e., [-9.9e16, 9.9e16]
