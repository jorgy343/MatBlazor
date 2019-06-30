using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class MatTextFieldValidation : MatTextField
    {
        /// <summary>
        /// Gets a string that indicates the status of the field being edited. This will include
        /// some combination of "modified", "valid", or "invalid", depending on the status of the field.
        /// </summary>
        protected string FieldClass => CurrentEditContext.FieldClass(FieldIdentifier);

        /// <summary>
        /// Gets the associated <see cref="Microsoft.AspNetCore.Components.Forms.EditContext"/>.
        /// </summary>
        protected EditContext CurrentEditContext { get; private set; }

        /// <summary>
        /// Gets the <see cref="FieldIdentifier"/> for the bound value.
        /// </summary>
        protected FieldIdentifier FieldIdentifier { get; private set; }

        [CascadingParameter]
        EditContext CascadedEditContext { get; set; }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<string>> ValueExpression { get; private set; }

        public MatTextFieldValidation()
        {
            HelperTextPersistent = true;
            HelperTextValidation = true;
        }

        protected override void OnValueChanged()
        {
            CurrentEditContext.NotifyFieldChanged(FieldIdentifier);

            var firstMessage = CurrentEditContext.GetValidationMessages(FieldIdentifier).FirstOrDefault();
            if (firstMessage == null)
            {
                HelperText = null;
            }
            else
            {
                HelperText = firstMessage;
            }

            StateHasChanged();
        }

        public override Task SetParametersAsync(ParameterCollection parameters)
        {
            parameters.SetParameterProperties(this);

            if (CurrentEditContext == null)
            {
                // This is the first run
                // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()

                if (CascadedEditContext == null)
                {
                    throw new InvalidOperationException($"{GetType()} requires a cascading parameter " +
                        $"of type {nameof(EditContext)}. For example, you can use {GetType().FullName} inside " +
                        $"an {nameof(EditForm)}.");
                }

                if (ValueExpression == null)
                {
                    throw new InvalidOperationException($"{GetType()} requires a value for the 'ValueExpression' " +
                        $"parameter. Normally this is provided automatically when using 'bind-Value'.");
                }

                CurrentEditContext = CascadedEditContext;
                FieldIdentifier = FieldIdentifier.Create(ValueExpression);
            }
            else if (CascadedEditContext != CurrentEditContext)
            {
                // We don't support changing EditContext because it's messy to be clearing up state and event
                // handlers for the previous one, and there's no strong use case. If a strong use case
                // emerges, we can consider changing this.
                throw new InvalidOperationException($"{GetType()} does not support changing the " +
                    $"{nameof(EditContext)} dynamically.");
            }

            // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
            return base.SetParametersAsync(ParameterCollection.Empty);
        }
    }
}