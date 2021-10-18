"use strict";

window.MdcBlazor = {
    attachRipple: {
        init: function ( elem ) {
            mdc.ripple.MDCRipple.attachTo( elem );
        }
    },

    attachUnboundRipple: {
        init: function ( elem ) {
            const iconButtonRipple = mdc.ripple.MDCRipple.attachTo( elem );
            iconButtonRipple.unbounded = true;
        }
    },

    checkbox: {
        init: function ( elem, formElem ) {
            const checkbox = mdc.checkbox.MDCCheckbox.attachTo( elem );
            const formField = mdc.formField.MDCFormField.attachTo( formElem );
            formField.input = checkbox;
        }
    },

    circularProgress: {
        init: function ( elem ) {
            mdc.circularProgress.MDCCircularProgress.attachTo( elem );
        }
    },

    dialog: {
        show: function ( elem, escapeAction, scrimAction ) {
            elem._dialog = elem._dialog || mdc.dialog.MDCDialog.attachTo( elem );
            if ( escapeAction !== null ) { elem._dialog.escapeKeyAction = escapeAction; }
            if ( scrimAction !== null ) { elem._dialog.scrimClickAction = scrimAction; }
            /* Call .layout on elements */
            elem._dialog.listen( 'MDCDialog:opened', () => {
                const radioElem = document.querySelector( '.mdc-dialog .mdc-radio' );
                const checkboxElem = document.querySelector( '.mdc-dialog .mdc-checkbox' );
                const iconButtonElem = document.querySelector( '.mdc-dialog .mdc-icon-button' );
                const switchElem = document.querySelector( '.mdc-dialog .mdc-switch' );
                if ( radioElem !== null ) { mdc.radio.MDCRadio.attachTo( radioElem ).layout; }
                if ( checkboxElem !== null ) { mdc.checkbox.MDCCheckbox.attachTo( checkboxElem ).layout; }
                if ( iconButtonElem !== null ) { const iconButton = mdc.ripple.MDCRipple.attachTo( iconButtonElem ); iconButton.unbounded = true; iconButton.layout; }
                if ( switchElem !== null ) { mdc.switchControl.MDCSwitch.attachTo( switchElem ).layout; }
            } );
            elem._dialog.open();
        },
        hide: function ( elem ) {
            if ( elem._dialog ) { elem._dialog.close(); }
        }
    },

    dialogWithCallback: {
        show: function ( elem, escapeAction, scrimAction ) {
            elem._dialog = elem._dialog || mdc.dialog.MDCDialog.attachTo( elem );
            if ( escapeAction !== null ) { elem._dialog.escapeKeyAction = escapeAction; }
            if ( scrimAction !== null ) { elem._dialog.scrimClickAction = scrimAction; }
            return new Promise( resolve => {
                const dialog = elem._dialog;
                const callback = event => {
                    dialog.unlisten( 'MDCDialog:closing', callback );
                    resolve( event.detail.action );
                };
                dialog.listen( 'MDCDialog:closing', callback );
                dialog.listen( 'MDCDialog:opened', () => {
                    const radioElem = document.querySelector( '.mdc-dialog .mdc-radio' );
                    const checkboxElem = document.querySelector( '.mdc-dialog .mdc-checkbox' );
                    const iconButtonElem = document.querySelector( '.mdc-dialog .mdc-icon-button' );
                    const switchElem = document.querySelector( '.mdc-dialog .mdc-switch' );
                    if ( radioElem !== null ) { mdc.radio.MDCRadio.attachTo( radioElem ).layout; }
                    if ( checkboxElem !== null ) { mdc.checkbox.MDCCheckbox.attachTo( checkboxElem ).layout; }
                    if ( iconButtonElem !== null ) { const iconButton = mdc.ripple.MDCRipple.attachTo( iconButtonElem ); iconButton.unbounded = true; iconButton.layout; }
                    if ( switchElem !== null ) { mdc.switchControl.MDCSwitch.attachTo( switchElem ).layout; }
                } );
                dialog.open();
            } );
        },
        hide: function ( elem, dialogAction ) {
            if ( elem._dialog ) {
                elem._dialog.close( dialogAction || 'dismissed' );
            }
        }
    },

    drawer: {
        toggle: function ( elem, isOpen ) {
            const drawer = mdc.drawer.MDCDrawer.attachTo( elem );
            drawer.open = isOpen;
        }
    },

    // Based on https://github.com/dotnet/aspnetcore/pull/23316/files#diff-e73ac8c2334b2a9377149d0b2b18993f8c68547e9016a0e5e48dda10ffd963b4R7
    focus: function ( elem ) {
        if ( elem instanceof HTMLElement ) {
            elem.focus();
        }
        else {
            throw new Error( 'Unable to focus an invalid element.' );
        }
    },

    iconToggle: {
        init: function ( elem ) {
            mdc.iconButton.MDCIconButtonToggle.attachTo( elem );
        }
    },

    linearProgress: {
        init: function ( elem ) {
            mdc.linearProgress.MDCLinearProgress.attachTo( elem );
        }
    },

    list: {
        init: function ( elem, isSingleSelection ) {
            elem._list = elem._list || mdc.list.MDCList.attachTo( elem );
            elem._list.setSingleSelection = isSingleSelection;
        },
        getSelectedIndex: function ( elem ) {
            if ( elem._list ) {
                return elem._list.selectedIndex;
            }
        },
        setSelectedIndex: function ( elem, newIndex ) {
            if ( elem._list ) {
                elem._list.selectedIndex = newIndex
            }
        },
        getSelectedValue: function ( elem ) {
            var selectedItem = elem.querySelector( ".mdc-deprecated-list-item--selected" );
            if ( selectedItem !== null && selectedItem.getAttribute( 'mb-data-list-item-value' ) ) {
                return selectedItem.getAttribute( 'mb-data-list-item-value' );
            }
        }
    },

    navDrawer: {
        // Inspired by: https://glitch.com/~material-responsive-drawer
        init: function ( drawerElement, listElement, mainContentElement, topAppBarElement ) {
            // Set CSS class on body element
            document.body.classList.add( "nav-drawer" );

            const initDismissibleDrawer = () => {
                // Select and remove scrim element if it exists
                const scrimElement = document.getElementsByClassName( "mdc-drawer-scrim" );
                if ( scrimElement.length > 0 ) { scrimElement[0].parentNode.removeChild( scrimElement[0] ); }

                // Change classes for dismissible
                drawerElement.classList.remove( "mdc-drawer--modal" );
                drawerElement.classList.add( "mdc-drawer--dismissible" );

                const drawer = mdc.drawer.MDCDrawer.attachTo( drawerElement );

                // Set drawer to open by default
                drawer.open = true;

                // Initialize top bar
                initTopAppBar();

                // Remove modal event listener
                listElement.removeEventListener( 'click', listItemListener );

                return drawer;
            };

            // Modal if screen size is less than 900px
            const initModalDrawer = () => {
                // Select scrim element and create if it does not exist
                const scrimElement = document.getElementsByClassName( "mdc-drawer-scrim" );
                if ( scrimElement.length === 0 ) {
                    const scrimElement = document.createElement( "DIV" );
                    scrimElement.classList.add( "mdc-drawer-scrim" );
                    drawerElement.parentNode.insertBefore( scrimElement, drawerElement.nextSibling );
                }

                // Change classes for modal
                drawerElement.classList.remove( "mdc-drawer--dismissible" );
                drawerElement.classList.add( "mdc-drawer--modal" );


                const drawer = mdc.drawer.MDCDrawer.attachTo( drawerElement );

                // Set drawer closed by default
                drawer.open = false;

                initTopAppBar();

                // Set drawer to close on selection
                listElement.addEventListener( 'click', listItemListener );
                return drawer;
            };

            const initTopAppBar = () => {
                const topAppBar = mdc.topAppBar.MDCTopAppBar.attachTo( topAppBarElement );
                topAppBar.setScrollTarget( mainContentElement );
                topAppBar.listen( 'MDCTopAppBar:nav', () => {
                    drawer.open = !drawer.open;
                } );
            };

            const listItemListener = (e) => {
                // Prevent closing on sub list
                if ( !e.target.matches( ".mdc-sub-list" ) ) {
                    drawer.open = false;
                }
            };

            // On initialized, set to dismissible if windows is 900px or wider, else use modal
            let drawer = window.matchMedia( "(min-width: 900px)" ).matches ? initDismissibleDrawer() : initModalDrawer();

            // Show or hide the drawer on resize
            const resizeHandler = () => {
                if ( window.matchMedia( "(max-width: 900px)" ).matches ) {
                    drawer.destroy();
                    drawer = initModalDrawer();
                } else if ( window.matchMedia( "(min-width: 901px)" ).matches ) {
                    drawer.destroy();
                    drawer = initDismissibleDrawer();
                }
            };
            window.addEventListener( 'resize', resizeHandler );
        }
    },

    radio: {
        init: function ( elem, formElem, groupValue = "", radioValue = "" ) {
            const radio = mdc.radio.MDCRadio.attachTo( elem );
            const formField = mdc.formField.MDCFormField.attachTo( formElem );
            formField.input = radio;

            if (( groupValue === radioValue) && (groupValue !== "" && radioValue !== "") ) {
                radio.checked = true;
            }
        }
    },

    select: {
        init: function ( elem, value = "" ) {
            elem._select = elem._select || mdc.select.MDCSelect.attachTo( elem );
            if ( value !== "" ) { elem._select.value = value; }
        },
        setValue: function ( elem, value ) {
            if ( elem._select ) {
                elem._select.value = value;
            }
        },
        setDisabled: function ( elem, value )
        {
            if ( elem._select ) {
                elem._select.disabled = value ;
            }
        }
    },

    switch: {
        init: function ( elem, isSelected = "" ) {
            elem._switch = elem._switch || mdc.switchControl.MDCSwitch.attachTo( elem );
            if ( isSelected !== "" ) { elem._switch.selected = isSelected }
        },
        setChecked: function ( elem, isSelected ) {
            if ( elem._switch ) {
                elem._switch.selected = isSelected;
            }
        },
        setDisabled: function ( elem, isDisabled ) {
            if ( elem._switch ) {
                elem._switch.disabled = isDisabled;
            }
        }
    },

    textField: {
        init: function ( elem, stopEnterKeyDownPropagation, helperTextElem, leadingIconElem, trailingIconElem, charCountElem ) {
            // Prevent submitting form on enter
            if ( stopEnterKeyDownPropagation ) { elem.addEventListener( 'keypress', function ( e ) { if ( e.keyCode === 13 ) { e.preventDefault(); } } ); }

            elem._textfield = elem._textfield || mdc.textField.MDCTextField.attachTo( elem );            
            if ( helperTextElem.__internalId !== null ) { mdc.textField.MDCTextFieldHelperText.attachTo( helperTextElem ); }
            if ( leadingIconElem.__internalId !== null ) { mdc.textField.MDCTextFieldIcon.attachTo( leadingIconElem ); }
            if ( trailingIconElem.__internalId !== null ) { mdc.textField.MDCTextFieldIcon.attachTo( trailingIconElem ); }
            if ( charCountElem.__internalId !== null ) { mdc.textField.MDCTextFieldCharacterCounter.attachTo( charCountElem ); }
        },
        layout: function ( elem ) {
            if ( elem._textfield ) {
                elem._textfield.layout();
            }
        }
    },

    topAppBar: {
        init: function ( elem, scrollTarget ) {
            const topAppBar = mdc.topAppBar.MDCTopAppBar.attachTo( elem );
            if ( scrollTarget ) {
                topAppBar.setScrollTarget( document.querySelector( scrollTarget ) );
            }
        }
    }
};