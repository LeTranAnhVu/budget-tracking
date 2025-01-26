export default function date2Str(date: Date): string {
    return date.toISOString().slice(0,10)
}