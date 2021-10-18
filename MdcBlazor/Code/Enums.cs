namespace MdcBlazor
{
    /// <summary>
    /// Sets the button style
    /// </summary>
    public enum MdcButtonStyle
    {
        /// <summary>No special styling.</summary>
        flat,
        /// <summary>Styles a contained button that is flush with the surface.</summary>
        unelevated,
        /// <summary>Styles a contained button that is elevated above the surface.</summary>
        raised,
        /// <summary>Styles an outlined button that is flush with the surface.</summary>
        outlined
    }

    /// <summary>
    /// Sets the button type
    /// </summary>
    public enum MdcButtonType
    {
        /// <summary>Button</summary>
        button,
        /// <summary>Submit</summary>
        submit
    }

    /// <summary>
    /// Sets the card content type
    /// </summary>
    public enum MdcCardContentType
    {
        /// <summary>This area is used to show different actions the user can take, typically at the bottom of a card. It's often used with buttons.</summary>
        actions,
        /// <summary>This area is used for showing rich media in cards, and optionally as a container.</summary>
        media,
        /// <summary>Use if a majority of the card (or even the entire card) should be actionable. Avoiding adding other actionable items within this content type.</summary>
        primaryaction,
        /// <summary>This area is used to show text.</summary>
        text
    }

    /// <summary>
    /// Sets the card display type
    /// </summary>
    public enum MdcCardDisplay
    {
        /// <summary>Elevated with no outline.</summary>
        elevated,
        /// <summary>Unelevated and outlined</summary>
        outlined
    }

    /// <summary>
    /// Sets the card media type. Used inside of a media content.
    /// </summary>
    public enum MdcCardMedia
    {
        /* mdc-card__media-content */
        /// <summary>An absolutely-positioned box the same size as the media area, for displaying a title or icon on top of the <c>background-image</c>.</summary>
        background,
        /* mdc-card__media--square */
        /// <summary>Automatically scales the media area's height to equal its width.</summary>
        square,
        /* mdc-card__media--16-9 */
        /// <summary>Automatically scales the media area's height according to its width, maintaining a 16:9 aspect ratio.</summary>
        widescreen,
        /// <summary>No special media styling.</summary>
        none
    }

    /// <summary>
    /// Sets the circular progress element size
    /// </summary>
    public enum MdcCircularProgressSize
    {
        /// <summary>48px</summary>
        large = 48,
        /// <summary>36px</summary>
        medium = 36,
        /// <summary>24px</summary>
        small = 24
    }

    /// <summary>
    /// <see href="https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofilling-form-controls:-the-autocomplete-attribute">HTML5 AutoComplete Types</see>
    /// </summary>
    public enum MdcInputAutoComplete
    {
        /// <summary>Indicates that the user agent is allowed to provide the user with autocompletion values, but does not provide any further information about what kind of data the user might be expected to enter.</summary>
        on,
        /// <summary>Indicates that the user will have to explicitly enter the data each time</summary>
        off,
        /// <summary>Full name</summary>
        name,
        /// <summary>Prefix or title (e.g. "Mr.", "Ms.", "Dr.")</summary>
        honorific_prefix,
        /// <summary>Given name, also known as the first name</summary>
        given_name,
        /// <summary>Additional names, also known as middle names</summary>
        additional_name,
        /// <summary>Family name, also known as the last name or surname</summary>
        family_name,
        /// <summary>Suffix (e.g. "Jr.", "II")</summary>
        honorific_suffix,
        /// <summary>Nickname, screen name, handle: a typically short name used instead of the full name</summary>
        nickname,
        /// <summary>A username</summary>
        username,
        /// <summary>A new password (e.g. when creating an account or changing a password)</summary>
        new_password,
        /// <summary>The current password for the account identified by the <c>username</c> field (e.g. when logging in)</summary>
        current_password,
        /// <summary>One-time code used for verifying user identity</summary>
        one_time_code,
        /// <summary>Job title (e.g. "Software Engineer", "Senior Vice President")</summary>
        organization_title,
        /// <summary>Company name corresponding to the person, address, or contact information in the other fields associated with this field</summary>
        organization,
        /// <summary>Street address (multiple lines, newlines preserved)</summary>
        street_address,
        /// <summary>Street address (one line per field)</summary>
        address_line1,
        /// <summary>Street address (one line per field)</summary>
        address_line2,
        /// <summary>Street address (one line per field)</summary>
        address_line3,
        /// <summary>The most fine-grained administrative level, in addresses with four <see href="https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#more-on-address-levels">administrative</see> levels</summary>
        address_level4,
        /// <summary>The <see href="https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#more-on-address-levels">third administrative level</see>, in addresses with three or more administrative levels</summary>
        address_level3,
        /// <summary>The <see href="https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#more-on-address-levels">second administrative level</see>, in addresses with two or more administrative levels; in the countries with two administrative levels, this would typically be the city, town, village, or other locality within which the relevant street address is found</summary>
        address_level2,
        /// <summary>The broadest <see href="https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#more-on-address-levels">administrative level</see> in the address, i.e. the province within which the locality is found; for example, in the US, this would be the state; in Switzerland it would be the canton; in the UK, the post town</summary>
        address_level1,
        /// <summary>Country code</summary>
        country,
        /// <summary>Country name</summary>
        country_name,
        /// <summary>Postal code, post code, ZIP code</summary>
        postal_code,
        /// <summary>Full name as given on the payment instrument</summary>
        cc_name,
        /// <summary>Given name as given on the payment instrument, also known as the first name</summary>
        cc_given_name,
        /// <summary>Additional names given on the payment instrument, also known as middle names</summary>
        cc_additional_name,
        /// <summary>Family name given on the payment instrument, also known as the last name or surname</summary>
        cc_family_name,
        /// <summary>Code identifying the payment instrument (e.g. the credit card number)</summary>
        cc_number,
        /// <summary>Expiration date of the payment instrument</summary>
        cc_exp,
        /// <summary>Month component of the expiration date of the payment instrument</summary>
        cc_exp_month,
        /// <summary>Year component of the expiration date of the payment instrument</summary>
        cc_exp_year,
        /// <summary>Security code for the payment instrument (also known as the card security code (CSC), card validation code (CVC), card verification value (CVV), signature panel code (SPC), credit card ID (CCID), etc)</summary>
        cc_csc,
        /// <summary>Type of payment instrument</summary>
        cc_type,
        /// <summary>The currency that the user would prefer the transaction to use</summary>
        transaction_currency,
        /// <summary>The amount that the user would like for the transaction (e.g. when entering a bid or sale price)</summary>
        transaction_amount,
        /// <summary>Preferred language</summary>
        language,
        /// <summary>Birthday</summary>
        bday,
        /// <summary>Day component of birthday</summary>
        bday_day,
        /// <summary>Month component of birthday</summary>
        bday_month,
        /// <summary>Year component of birthday</summary>
        bday_year,
        /// <summary>Gender identity (e.g. Female)</summary>
        sex,
        /// <summary>Home page or other Web page corresponding to the company, person, address, or contact information in the other fields associated with this field</summary>
        url,
        /// <summary>Photograph, icon, or other image corresponding to the company, person, address, or contact information in the other fields associated with this field</summary>
        photo,
        /// <summary>Full telephone number, including country code</summary>
        tel,
        /// <summary>Country code component of the telephone number</summary>
        tel_country_code,
        /// <summary>Telephone number without the county code component, with a country-internal prefix applied if applicable</summary>
        tel_national,
        /// <summary>Area code component of the telephone number, with a country-internal prefix applied if applicable</summary>
        tel_area_code,
        /// <summary>Telephone number without the country code and area code components</summary>
        tel_local,
        /// <summary>First part of the component of the telephone number that follows the area code, when that component is split into two components</summary>
        tel_local_prefix,
        /// <summary>Second part of the component of the telephone number that follows the area code, when that component is split into two components</summary>
        tel_local_suffix,
        /// <summary>Telephone number internal extension code</summary>
        tel_extension,
        /// <summary>E-mail address</summary>
        email,
        /// <summary>URL representing an instant messaging protocol endpoint (for example, "aim:goim?screenname=example" or "xmpp:fred@example.net")</summary>
        impp
    }

    /// <summary>
    /// Sets the position property of the <see cref="MdcInputAutoComplete"/> displayed list
    /// </summary>
    public enum MdcAutocompleteListPosition
    {
        /// <summary>absolute</summary>
        _absolute,
        /// <summary>fixed</summary>
        _fixed
    }

    /// <summary>
    /// Sets the select style
    /// </summary>
    public enum MdcSelectStyle
    {
        /// <summary>No special styling</summary>
        flat,
        /// <summary>Styles the select as outlined select.</summary>
        outlined
    }

    /// <summary>
    /// Sets the table column order
    /// </summary>
    public enum MdcTableColumnOrderBy
    {
        /// <summary>Ascending order</summary>
        ascending,
        /// <summary>Descending order</summary>
        descending
    }

    /// <summary>
    /// Sets the number of results displayed per page in a table
    /// </summary>
    public enum MdcTablePageSize
    {
        /// <summary>5</summary>
        _5 = 5,
        /// <summary>10</summary>
        _10 = 10,
        /// <summary>25</summary>
        _25 = 25,
        /// <summary>50</summary>
        _50 = 50,
        /// <summary>100</summary>
        _100 = 100,
        /// <summary>500</summary>
        _500 = 500,
        /// <summary>1000</summary>
        _1000 = 1000
    }

    /// <summary>
    /// Sets the pagination display logic
    /// </summary>
    public enum MdcTablePaginationDisplay
    {
        /// <summary>Always display pagination</summary>
        always,
        /// <summary>Hide pagination if result count is less than page size</summary>
        autohide,
        /// <summary>Never show pagination</summary>
        never
    }

    /// <summary>
    /// Sets the text field style
    /// </summary>
    public enum MdcTextFieldStyle
    {
        /// <summary>No special styling</summary>
        flat,
        /// <summary>Styles the text field as an outlined text field.</summary>
        outlined
    }

    /// <summary>
    /// Sets the text field type
    /// </summary>
    public enum MdcTextFieldType
    {
        /// <summary>Defines a text field that should contain a color</summary>
        color,
        /// <summary>Defines a text field that should contain a date</summary>
        date,
        /// <summary>Defines a text field that should contain a date and a time, including the year, month, and day as well as the time in hours and minutes</summary>
        datetime_local,
        /// <summary>Defines a text field that should contain a month and year</summary>
        month,
        /// <summary>Defines a text field that should contain a a time (hours and minutes, and optionally seconds)</summary>
        time,
        /// <summary>Defines a text field that should contain an e-mail address</summary>
        email,
        /// <summary>Defines file-select text field and a "Browse" button for file uploads</summary>
        file,
        /// <summary>Defines a text field that should contain a number</summary>
        number,
        /// <summary>Defines a password field</summary>
        password,
        /// <summary>Defines a search text field</summary>
        search,
        /// <summary>Defines a text field that should contain a telephone number</summary>
        tel,
        /// <summary>Defines a single-line text input</summary>
        text,
        /// <summary>Defines a text field that should contain an URL address</summary>
        url
    }
}
