

fun xorSum(args: Array<Int>) : Int{
    var acc = 0;
    args.forEach (
        {
            i -> acc = (acc xor i)
        }
    );
    return  acc;
}

fun main(args: Array<String>) {
    print(xorSum(arrayOf(3,4,5)))
}